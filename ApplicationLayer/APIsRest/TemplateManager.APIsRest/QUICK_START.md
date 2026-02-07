# 🚀 Guida Rapida - TemplateManager API

## 📋 Prerequisiti

- ✅ .NET 8.0 SDK
- ✅ SQL Server (con database configurato)
- ✅ Visual Studio 2022 / VS Code / Rider
- ✅ (Opzionale) Node.js 20+ per frontend React

---

## 🔧 Installazione e Avvio

### 1. Clone Repository
```bash
# Già clonato in:
C:\SolutionMyEpy\TemplateManager
```

### 2. Restore Packages
```bash
cd ApplicationLayer/APIsRest/TemplateManager.APIsRest
dotnet restore
```

### 3. Configurazione Database
**File:** `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=TemplateManager;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Build Progetto
```bash
dotnet build
```

### 5. Avvia API
```bash
dotnet run
```

**API disponibile su:**
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `http://localhost:5000/swagger`

---

## 📡 Test Endpoints

### 1. Health Check
```bash
curl http://localhost:5000/api/health
```

**Response:**
```json
{
  "status": "healthy",
  "timestamp": "2025-11-08T10:30:00Z",
  "version": "2.0.0"
}
```

### 2. Generazione PDF con QuestPDF (RACCOMANDATO)
```bash
curl -X POST http://localhost:5000/api/offers/generate \
  -H "Content-Type: application/json" \
  -d '{
    "codeOffer": "OF-2025-001",
    "companyName": "Acme S.p.A.",
    "customer": "Mario Rossi",
    "emailCustomer": "mario.rossi@example.com",
    "dateOffer": "2025-11-08",
    "alphaCode": "IT",
    "codeTemplate": 1
  }'
```

### 3. Preview HTML
```bash
curl -X POST http://localhost:5000/api/offers/preview \
  -H "Content-Type: application/json" \
  -d '{
    "codeOffer": "OF-2025-001",
    "companyName": "Acme S.p.A.",
    "customer": "Mario Rossi",
    "dateOffer": "2025-11-08",
    "alphaCode": "IT",
    "codeTemplate": 1
  }' > preview.html
```

### 4. Genera PDF e Invia Email
```bash
curl -X POST http://localhost:5000/api/offers/pdf/email \
  -H "Content-Type: application/json" \
  -d '{
    "emailAddress": "mario.rossi@example.com",
    "subject": "Offerta Commerciale",
    "bodyHtml": "<p>In allegato trovi il PDF dell'\''offerta.</p>",
    "offer": {
      "codeOffer": "OF-2025-001",
      "companyName": "Acme S.p.A.",
      "customer": "Mario Rossi",
      "dateOffer": "2025-11-08",
      "alphaCode": "IT",
      "codeTemplate": 1
    }
  }'
```

---

## 🗄️ Struttura Database

### Tabella: Template
```sql
CREATE TABLE Template (
    Id INT PRIMARY KEY IDENTITY,
    Code INT NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    AlphaCode NVARCHAR(10), -- IT, EN
    Description NVARCHAR(MAX)
)
```

### Tabella: TemplateParagraph
```sql
CREATE TABLE TemplateParagraph (
    Id INT PRIMARY KEY IDENTITY,
    CodeTemplate INT NOT NULL,
    NameOfTemplate NVARCHAR(100) NOT NULL, -- DefinitionOfOffer, Delivery, etc.
    AlphaCode NVARCHAR(10) NOT NULL,       -- IT, EN
    PositionIndex INT,
    Title NVARCHAR(200),
    Subtitle NVARCHAR(200),
    Paragraph NVARCHAR(MAX),               -- HTML con placeholders: {{NameClient}}, {{CompanyName}}
    PresentationInfo NVARCHAR(MAX)
)
```

### Dati di Esempio
```sql
-- Inserisci sezione "DefinitionOfOffer" in italiano
INSERT INTO TemplateParagraph 
  (CodeTemplate, NameOfTemplate, AlphaCode, PositionIndex, Title, Paragraph)
VALUES
  (1, 'DefinitionOfOffer', 'IT', 1, 'Descrizione del Prodotto', 
   '<p>Gentile {{NameClient}}, la società {{CompanyName}} Le propone...</p>'),
   
  (1, 'Delivery', 'IT', 1, 'Consegna', 
   '<p>La consegna avverrà entro la data {{Date}}.</p>'),
   
  (1, 'PaymentConditions', 'IT', 1, 'Condizioni di Pagamento', 
   '<p>Il pagamento dovrà essere effettuato entro 30 giorni.</p>')
```

**Sezioni Supportate:**
- `DefinitionOfOffer`
- `ConditionForTermination` o `ConditionTermination`
- `AssistanceAndMaintenance`
- `Delivery`
- `InstallationAndInstruction`
- `PaymentConditions`
- `AttachmentsConditions`
- `OfferConditions`
- `OfferAcceptanceSignatures`

---

## 🎯 Uso con Postman

### Collection Import
Crea nuova collection "TemplateManager API" con questi endpoints:

#### 1. Generate PDF (QuestPDF)
- **Method:** POST
- **URL:** `{{baseUrl}}/api/offers/generate`
- **Headers:** `Content-Type: application/json`
- **Body (raw JSON):**
```json
{
  "codeOffer": "OF-2025-001",
  "companyName": "Acme S.p.A.",
  "customer": "Mario Rossi",
  "emailCustomer": "mario.rossi@example.com",
  "dateOffer": "2025-11-08T00:00:00",
  "alphaCode": "IT",
  "codeTemplate": 1
}
```

#### 2. PDF + Email
- **Method:** POST
- **URL:** `{{baseUrl}}/api/offers/pdf/email`
- **Headers:** `Content-Type: application/json`
- **Body:** Vedere esempio sopra

**Environment Variables:**
```
baseUrl = http://localhost:5000
```

---

## 🔍 Debugging

### Visualizzare Logs
```bash
dotnet run --verbosity detailed
```

### Test Endpoint Specifico
```powershell
# PowerShell
$body = @{
    codeOffer = "OF-2025-001"
    companyName = "Acme S.p.A."
    customer = "Mario Rossi"
    dateOffer = "2025-11-08"
    alphaCode = "IT"
    codeTemplate = 1
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5000/api/offers/generate" `
                  -Method Post `
                  -Body $body `
                  -ContentType "application/json"
```

### Verificare Connessione DB
```csharp
// In Program.cs aggiungi temporaneamente:
app.MapGet("/api/test-db", async () => {
    var service = app.Services.GetRequiredService<ITemplateParagraphServiceApi>();
    var criteria = new TemplateParagraphApiSearchCriteria { 
        CodeTemplate = 1, 
        AlphaCode = "IT" 
    };
    var result = await service.LoadListAsync(criteria);
    return Results.Ok(new { 
        count = result.ListTemplateParagraph?.Count ?? 0,
        items = result.ListTemplateParagraph
    });
});
```

---

## ⚠️ Troubleshooting

### Errore: QuestPDF License
```
Solution: Assicurati che Program.cs contenga:
QuestPDF.Settings.License = LicenseType.Community;
```

### Errore: Cannot find EmailNotification.dll
```
Solution: Le DLL devono essere in Library/:
- EmailNotification.Common.dll
- EmailNotification.UI.dll
Sono già incluse nel progetto.
```

### Errore: Chromium not found (Puppeteer)
```bash
# Download automatico Chromium
cd ApplicationLayer/APIsRest/TemplateManager.APIsRest
dotnet run

# Puppeteer scaricherà automaticamente Chromium al primo avvio
```

### Errore: CORS policy
```
Verifica che Program.cs contenga:
builder.Services.AddCors(...)
app.UseCors();
```

---

## 📚 Documentazione Aggiuntiva

### API Documentation
- Swagger UI: `http://localhost:5000/swagger`
- JSON Schema: `http://localhost:5000/swagger/v1/swagger.json`

### Codice Sorgente
- Controllers: `ApplicationLayer/APIsRest/TemplateManager.APIsRest/Controllers/`
- Services: `DomainService/TemplateManager.APIs/DomainService/`
- Models: `DomainService/TemplateManager.Common/ObjectModel/`
- Database: `Core/TemplateManager.DAL/`

### Files Principali da Studiare:
1. **Program.cs** - Configurazione DI e middleware
2. **OffersController.cs** - Endpoints API
3. **OfferPdfDocument.cs** - Struttura PDF con QuestPDF
4. **OfferTemplateServiceApi.cs** - Logica caricamento dati DB
5. **OfferPdfEmailService.cs** - Integrazione con Email API

---

