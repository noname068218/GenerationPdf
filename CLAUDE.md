# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

TemplateManager is a .NET 8.0 solution that manages document templates and generates PDF offers dynamically. The system uses QuestPDF for modern PDF generation and follows Domain-Driven Design (DDD) principles with a layered architecture. The REST API allows clients to generate customized PDFs from database templates with placeholder substitution.

## Build and Run Commands

### Build the solution
```bash
dotnet build TemplateManager.sln
```

### Build specific projects
```bash
# REST API
dotnet build ApplicationLayer/APIsRest/TemplateManager.APIsRest/TemplateManager.APIsRest.csproj

# Core domain library
dotnet build Core/TemplateManager/TemplateManager.csproj

# Tests
dotnet build TemplateManager.TestAPIs/TemplateManager.TestAPIs.csproj
```

### Run the REST API
```bash
cd ApplicationLayer/APIsRest/TemplateManager.APIsRest
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `http://localhost:5000/swagger`

### Run tests
```bash
dotnet test TemplateManager.TestAPIs/TemplateManager.TestAPIs.csproj
```

### Run specific test class
```bash
dotnet test --filter "FullyQualifiedName~LicenseManager.TestAPIs.BaseTest"
```

## Architecture and Structure

### Layered Architecture (Domain-Driven Design)

The solution follows a strict 3-layer DDD architecture with clear separation of concerns:

```
┌─────────────────────────────────────────────────┐
│  ApplicationLayer (Presentation)                │
│  - APIsRest: REST API Controllers               │
│  - WebSite: MVC/Razor Web UI                    │
└─────────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────────┐
│  DomainService (Application Services)           │
│  - TemplateManager.APIs: API-specific services  │
│  - TemplateManager.Common: DTOs and contracts   │
│  - TemplateManager.UI: UI-specific services     │
└─────────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────────┐
│  Core (Domain + Data Access)                    │
│  - TemplateManager: Domain logic, services,     │
│    entities, builders, validators               │
│  - TemplateManager.DAL: Data access layer       │
│    (Gateway pattern, ObjectModel entities)      │
└─────────────────────────────────────────────────┘
```

**Key Points:**
- **Core/TemplateManager**: Domain entities, business logic, validators, builders
- **Core/TemplateManager.DAL**: Data access via Gateway pattern, uses stored procedures (not EF Core)
- **DomainService/TemplateManager.APIs**: Async API services wrapping synchronous domain services
- **ApplicationLayer**: Controllers and UI that delegate to DomainService APIs

### Service Locator Pattern (Not Modern DI)

The codebase uses a **legacy Service Locator pattern** for dependency resolution instead of constructor-based dependency injection. This is critical to understand when modifying code.

**Three service locators exist:**
1. **DomainServiceLocator** (`Core/TemplateManager/Application/DomainServiceLocator.cs`)
   - Manages domain services: TemplateService, TemplateParagraphService
   - Access via: `DomainServiceLocator.GetTemplateService()`

2. **ServiceLocator (DAL)** (`Core/TemplateManager.DAL/Application/ServiceLocator.cs`)
   - Manages data access: GatewayFactory, ObjectModelFactory
   - Access via: `ServiceLocator.GetGatewayFactory()`

3. **DomainServiceAPIs** (`DomainService/TemplateManager.APIs/Application/DomainServiceAPIs.cs`)
   - Manages API services: TemplateServiceApi, TemplateParagraphServiceApi
   - Access via: `DomainServiceAPIs.GetTemplateServiceApi()`

**Initialization:**
The Service Locator is bootstrapped in `Program.cs`:
```csharp
TemplateManager.APIs.Application.BootStrapper.Initialize();
```

**Implications:**
- Services require parameterless constructors for reflection-based instantiation
- Dependencies are resolved via static methods, not injected
- Modern ASP.NET Core DI is used only for new API-specific services (QuestPdfRenderer, OfferPdfEmailService)

### Gateway Pattern for Data Access

All database operations use the **Gateway pattern** (similar to Repository pattern):

**Flow:**
```
Controller
  ↓
DomainServiceAPI (async wrapper)
  ↓
DomainService (sync)
  ↓
Gateway (Repository)
  ↓
SQL Server (Stored Procedures)
```

**Key files:**
- Gateway contracts: `Core/TemplateManager.DAL/Gateway/Contracts/`
- Gateway implementations: `Core/TemplateManager.DAL/Gateway/Concrete/`
- Gateway factory: `Core/TemplateManager.DAL/Gateway/Factory/GatewayFactory.cs`

**Example:**
```csharp
// Get gateway via Service Locator
var gateway = ServiceLocator.GetGatewayFactory().GetTemplateGateway();

// CRUD operations
var template = gateway.GetById(id);
var results = gateway.Search(new TemplateSearchCriteria { AlphaCode = "IT" });
gateway.Save(templateObjectModel);
gateway.Delete(templateObjectModel, new TemplateDeleteArgs { IsSoftDelete = true });
```

### Builder Pattern for Business Operations

Complex business operations use the **Builder pattern** to encapsulate logic before persistence:

**Location:** `Core/TemplateManager/Business/Builders/`

**Flow:**
```csharp
// 1. Get builder from factory
var builder = DomainServiceLocator.GetBuilderFactory().GetTemplateSaveBuilder();

// 2. Apply business logic
builder.Build(templateEntity, new TemplateSaveBuilderArgs());

// 3. Persist via gateway
gateway.Save(templateEntity.ToObjectModel());
```

**Key files:**
- Builder contracts: `Business/Builders/Contracts/`
- Builder implementations: `Business/Builders/Concrete/`
- Builder factory: `Business/Builders/Factory/BuilderFactory.cs`

### Validation Strategy

Two validation layers exist:

1. **Domain Validators** (`Business/Validators/`)
   - Validate business rules (e.g., duplicate checks)
   - Called explicitly before save operations
   - Example: `TemplateValidator.Validate(template)`

2. **FluentValidation** (API layer)
   - Validates API DTOs
   - Configured in `Program.cs` via `AddFluentValidation()`

**Key files:**
- Validator contracts: `Business/Validators/Template/ITemplateValidator.cs`
- Validator implementations: `Business/Validators/Template/TemplateValidator.cs`
- Validator factory: `Business/Validators/Factory/ValidatorsFactory.cs`

### Domain Object Wrapping Pattern

The architecture uses a **Wrapper pattern** to separate domain logic from persistence:

- **ObjectModel** (`TemplateManager.DAL/DomainModel/Concrete/`): EF-like entities for persistence
- **DomainObject** (`TemplateManager/DomainObject/Concrete/`): Wraps ObjectModel, adds business logic

**Conversion:**
```csharp
// Domain to ObjectModel (for persistence)
ITemplateObjectModel objectModel = domainTemplate.ToObjectModel();

// ObjectModel to Domain (after retrieval)
ITemplate domain = objectModel.ToDomainObject();
```

## Key Concepts

### Database Communication

- Uses **ADO.NET with stored procedures**, not Entity Framework Core queries
- Connection string configured in `appsettings.json`
- Stored procedures expected: `SP_Template_Insert`, `SP_Template_Update`, `SP_Template_Search`, `SP_Template_Delete`, `SP_TemplateParagraph_*`, etc.
- Soft delete supported via `IsSoftDelete` flag in DeleteArgs

### Template System

Templates are stored in database with placeholders that get replaced at runtime:

**Database tables:**
- **Template**: Defines template metadata (Code, Name, AlphaCode)
- **TemplateParagraph**: Contains HTML paragraphs with placeholders

**Placeholder format:** `{{VariableName}}`

**Example:**
```html
<p>Gentile {{NameClient}}, la società {{CompanyName}} Le propone...</p>
```

**Sections supported:**
- DefinitionOfOffer
- ConditionForTermination / ConditionTermination
- AssistanceAndMaintenance
- Delivery
- InstallationAndInstruction
- PaymentConditions
- AttachmentsConditions
- OfferConditions
- OfferAcceptanceSignatures

### PDF Generation

The system uses **QuestPDF** (modern, fast) for PDF generation:

**Configuration:**
```csharp
// In Program.cs
QuestPDF.Settings.License = LicenseType.Community;

// Register services
builder.Services.AddScoped<IQuestPdfRenderer, QuestPdfRenderer>();
builder.Services.AddScoped<IOfferTemplateServiceApi, OfferTemplateServiceApi>();
```

**Key files:**
- PDF document structure: `DomainService/TemplateManager.APIs/DomainService/Concrete/QuestPdf/OfferPdfDocument.cs`
- Renderer: `DomainService/TemplateManager.APIs/DomainService/Concrete/QuestPdf/QuestPdfRenderer.cs`

### Authentication and Authorization

The API uses:
- **Basic Auth Middleware** for API authentication
- **Cookie Authentication** for web UI
- **Policy-based authorization** with three levels:
  - ReadonlyPolicy
  - WritePolicy
  - FullControlPolicy

**Configuration in Program.cs:**
```csharp
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
builder.Services.AddAuthorization(options => { ... })
app.UseMiddleware<BasicAuthMiddleware>();
```

## External Dependencies

### Library/ Directory (DLL References)

The solution references precompiled DLLs from `Library/`:
- **Standard.Common.dll**: Common utilities
- **Standard.ef.dll**: EF utilities
- **EmailNotification.Common.dll / EmailNotification.UI.dll**: Email functionality
- **UserManager.Common.dll / UserManager.UI.dll**: User management
- **UserAzureActiveDirectory.Plugin.dll**: Azure AD integration
- **IncidentManager.Common.dll / IncidentManager.UI.dll**: Incident tracking
- **EVentLogOnSite.Common.dll / EVentLogOnSite.UI.dll**: Event logging
- **TraceActivityAPIsRest.dll / TraceActivityAPIsRest.DAL.dll**: Activity tracing

These are legacy dependencies and their source code is not in this repository.

## Development Guidelines

### Adding a New Entity

1. **Create ObjectModel** in `Core/TemplateManager.DAL/DomainModel/Concrete/YourEntity.cs`
2. **Create Gateway** in `Core/TemplateManager.DAL/Gateway/Concrete/YourEntityGateway.cs`
3. **Create Domain Object** in `Core/TemplateManager/DomainObject/Concrete/YourEntity.cs`
4. **Create Domain Service** in `Core/TemplateManager/DomainService/ServiceCore/Concrete/YourEntityService.cs`
5. **Create Validator** in `Core/TemplateManager/Business/Validators/YourEntity/YourEntityValidator.cs`
6. **Create Builder** in `Core/TemplateManager/Business/Builders/Concrete/YourEntity/YourEntitySaveBuilder.cs`
7. **Create API Service** in `DomainService/TemplateManager.APIs/DomainService/Concrete/YourEntity/YourEntityServiceApi.cs`
8. **Create API DTO** in `DomainService/TemplateManager.Common/ObjectModel/YourEntityApi.cs`
9. **Create Controller** in `ApplicationLayer/APIsRest/TemplateManager.APIsRest/Controllers/YourEntityController.cs`
10. **Add to Service Locators** in respective `DomainServiceLocator.cs`, `DomainServiceAPIs.cs`
11. **Create stored procedures**: `SP_YourEntity_Insert`, `SP_YourEntity_Update`, `SP_YourEntity_Search`, `SP_YourEntity_Delete`

### Modifying Existing Services

When modifying domain services:
1. Services use **lazy initialization** via properties (not constructor injection)
2. Dependencies are resolved via Service Locator pattern
3. Gateway operations use ObjectModel entities (call `.ToObjectModel()` before persistence)
4. Always validate before save: `CanSave(entity)` or explicit `Validator.Validate(entity)`
5. Use builders to apply business logic: `Builder.Build(entity, args)`

### API Controller Pattern

Controllers delegate to DomainServiceAPIs:
```csharp
[Route("ServiceApi/V1.0/[controller]")]
[ApiController]
public class TemplateController : ControllerBase
{
    [HttpPost]
    [Route("SaveAsync")]
    public async Task<FeedBackOperation> SaveAsync([FromBody] TemplateApi input)
    {
        return await DomainServiceAPIs.GetTemplateServiceApi().SaveAsync(input);
    }
}
```

Do not inject services via constructor in controllers accessing legacy domain services—use Service Locator.

### Testing

- Test project: `TemplateManager.TestAPIs`
- Test framework: MSTest
- Base test class: `BaseTest` provides transaction scope for DB tests
- Tests use `TransactionScope` for automatic rollback
- Run tests with: `dotnet test`

### Configuration

**appsettings.json** contains:
- Connection strings for SQL Server
- CORS settings
- Logging configuration
- Email settings (via EmailNotification DLLs)

**Important:** Connection string must include `TrustServerCertificate=True` for local SQL Server.

## Common Tasks

### Generate a PDF from a template

```csharp
// 1. Load template paragraphs from DB
var service = DomainServiceAPIs.GetTemplateParagraphServiceApi();
var result = await service.LoadListAsync(new TemplateParagraphApiSearchCriteria
{
    CodeTemplate = 1,
    AlphaCode = "IT"
});

// 2. Replace placeholders
var replacements = new Dictionary<string, string>
{
    { "{{NameClient}}", "Mario Rossi" },
    { "{{CompanyName}}", "Acme S.p.A." },
    { "{{Date}}", DateTime.Now.ToShortDateString() }
};

// 3. Generate PDF with QuestPDF
var renderer = app.Services.GetRequiredService<IQuestPdfRenderer>();
var pdfBytes = renderer.GeneratePdf(offerData);
```

### Query templates with specific criteria

```csharp
var service = DomainServiceAPIs.GetTemplateServiceApi();
var result = await service.LoadListAsync(new TemplateApiSearchCriteria
{
    AlphaCode = "IT",
    Name = "ContractTemplate"
});

var templates = result.ListTemplate;
```

### Add a new template paragraph

```csharp
var paragraph = new TemplateParagraphApi
{
    CodeTemplate = 1,
    NameOfTemplate = "DefinitionOfOffer",
    AlphaCode = "IT",
    PositionIndex = 1,
    Title = "Descrizione Prodotto",
    Paragraph = "<p>Gentile {{NameClient}}...</p>"
};

var feedback = await DomainServiceAPIs
    .GetTemplateParagraphServiceApi()
    .SaveAsync(paragraph);
```

## Troubleshooting

### "Service not registered" error
Ensure `BootStrapper.Initialize()` is called in `Program.cs` before services are used.

### QuestPDF license error
Verify `QuestPDF.Settings.License = LicenseType.Community;` is set in `Program.cs`.

### Database connection issues
Check `appsettings.json` for correct connection string. Ensure SQL Server is running and database exists. Verify stored procedures are created.

### Missing DLL references
Ensure all DLLs in `Library/` directory are present and correctly referenced in `.csproj` files with `<HintPath>` pointing to the correct location.
