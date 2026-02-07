using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TemplateManager.Common.ObjectModel;
using TemplateManager.Common.ObjectModel.Contract;
using TemplateManager.APIs.DomainService;

namespace TemplateManager.APIs.DomainService.Concrete.QuestPdf
{
    /// <summary>
    /// Documento PDF per offerta commerciale.
    /// Implementa IDocument di QuestPDF per definire layout e contenuto.
    /// </summary>
    internal class OfferPdfDocument : IDocument
    {
        #region CAMPI

        private readonly OfferContract _model;
        private readonly HtmlToPdfRenderer _htmlRenderer;

        // Modern color palette - professional and attractive
        private readonly string ColorPrimary = "#1a365d";        // Deep professional blue
        private readonly string ColorSecondary = "#2d5aa0";      // Vibrant blue
        private readonly string ColorAccent = "#4299e1";         // Bright accent blue
        private readonly string ColorSuccess = "#38a169";        // Green for positive elements
        private readonly string ColorText = "#2d3748";           // Dark gray for excellent readability
        private readonly string ColorTextLight = "#4a5568";       // Medium gray for secondary text
        private readonly string ColorBorder = "#e2e8f0";         // Light border
        private readonly string ColorBackground = "#90CAF9";     // Very light background
        private readonly string ColorCardBackground = "#ffffff";  // White for cards
        private readonly string ColorHighlight = "#edf2f7";      // Highlight background


        #endregion

        #region COSTRUTTORI


        /// <summary>
        /// Costruttore che riceve il contratto dell'offerta.
        /// </summary>
        /// <param name="model">Dati dell'offerta da renderizzare</param>
        public OfferPdfDocument(OfferContract model)
        {
            _model = model;
            _htmlRenderer = new HtmlToPdfRenderer(
                defaultFontSize: 11f,
                defaultTextColor: ColorText
            );
        }

        #endregion

        #region METODI - Implementazione IDocument

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20, Unit.Millimetre);

                    page.DefaultTextStyle(x => x
                        .FontSize(11)
                        .FontFamily("Arial")
                        .FontColor(ColorText));

                    page.Header().ShowOnce().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Pagina ");
                        text.CurrentPageNumber();
                        text.Span(" di ");
                        text.TotalPages();
                    });
                });
        }

        #endregion

        #region METODI - Composizione sezioni documento

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item()
                    .PaddingVertical(10)
                    .Background(Colors.Grey.Lighten4)
                    .BorderLeft(4)
                    .BorderColor(ColorAccent)
                    .Padding(15)
                    .Column(infoColumn =>
                    {
                        infoColumn.Item()
                            .Text("Spett.le")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Medium);

                        infoColumn.Item()
                            .Text(_model.CompanyName ?? "")
                            .Bold()
                            .FontSize(14)
                            .FontColor(ColorPrimary);

                        if (!string.IsNullOrWhiteSpace(_model.Customer))
                        {
                            infoColumn.Item().PaddingTop(5).Row(row =>
                            {
                                row.AutoItem().Text("C.a. ").FontSize(10);
                                row.AutoItem().Text(_model.Customer).Bold().FontSize(10);
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(_model.EmailCustomer))
                        {
                            infoColumn.Item()
                                .Text(_model.EmailCustomer)
                                .FontSize(9)
                                .FontColor(Colors.Grey.Medium);
                        }
                    });

                column.Item().PaddingTop(15).Row(row =>
                {
                    row.RelativeItem().Text(text =>
                    {
                        text.Span("Offerta n. ").FontSize(12);
                        text.Span(_model.CodeOffer ?? "")
                            .Bold()
                            .FontSize(14)
                            .FontColor(ColorPrimary);
                    });

                    row.ConstantItem(150).AlignRight()
                        .Text($"Data: {_model.DateOffer:dd/MM/yyyy}")
                        .FontSize(10)
                        .FontColor(Colors.Grey.Medium);
                });

                column.Item()
                    .PaddingTop(10)
                    .LineHorizontal(2)
                    .LineColor(ColorPrimary);
            });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(15).Column(column =>
            {
                if (_model.DefinitionOfOffer != null)
                {
                    column.Item().Element(c => ComposeDefinitionOfOffer(c, _model.DefinitionOfOffer));
                }

                if (_model.ConditionForTermination != null)
                {
                    column.Item().Element(c => ComposeConditionForTermination(c, _model.ConditionForTermination));
                }

                if (_model.AssistanceAndMaintenance != null)
                {
                    column.Item().Element(c => ComposeAssistanceAndMaintenance(c, _model.AssistanceAndMaintenance));
                }

                if (_model.AssetOfOfferCosts != null)
                {
                    column.Item().PaddingTop(20).Element(c => ComposeAssetOfOfferCosts(c, _model.AssetOfOfferCosts));
                }

                if (_model.Delivery != null)
                {
                    column.Item().Element(c => ComposeDelivery(c, _model.Delivery));
                }

                if (_model.InstallationAndInstruction != null)
                {
                    column.Item().Element(c => ComposeInstallationAndInstruction(c, _model.InstallationAndInstruction));
                }

                if (_model.PaymentConditions != null)
                {
                    column.Item().Element(c => ComposePaymentConditions(c, _model.PaymentConditions));
                }

                if (_model.AttachmentsConditions != null)
                {
                    column.Item().Element(c => ComposeAttachmentsConditions(c, _model.AttachmentsConditions));
                }

                if (_model.OfferConditions != null)
                {
                    column.Item().Element(c => ComposeOfferConditions(c, _model.OfferConditions));
                }

                if (_model.OfferAcceptanceSignatures != null)
                {
                    column.Item().Element(c => ComposeOfferAcceptanceSignatures(c, _model.OfferAcceptanceSignatures));
                }
            });
        }

        private void ComposeDefinitionOfOffer(IContainer container, DefinitionOfOffer? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("1. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Subtitle))
                    {
                        var subtitleRenderer = new HtmlToPdfRenderer(
                            defaultFontSize: 9f,
                            defaultTextColor: ColorSecondary
                        );

                        column.Item()
                            .PaddingBottom(8)
                            .PaddingTop(4)
                            .PaddingLeft(20)
                            .Element(c => subtitleRenderer.ComposeHtmlContent(c, section.Subtitle));
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }

                    if (section.ProductsDescription?.Any() == true)
                    {
                        column.Item()
                            .PaddingTop(20)
                            .Element(c => ComposeProductList(c, section.ProductsDescription));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Assistenza e Manutenzione.
        /// </summary>
        private void ComposeAssistanceAndMaintenance(IContainer container, AssistanceAndMaintenance? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("3. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("3. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Assistenza e Manutenzione")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Condizioni di Cessazione.
        /// </summary>
        private void ComposeConditionForTermination(IContainer container, ConditionForTermination? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("2. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("2. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Condizioni di Cessazione")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Allegati.
        /// </summary>
        private void ComposeAttachmentsConditions(IContainer container, AttachmentsConditions? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("8. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("8. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Allegati")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Condizioni d'Offerta.
        /// </summary>
        private void ComposeOfferConditions(IContainer container, OfferConditions? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("9. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("9. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Condizioni d'Offerta")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        var definitionContent = section.Definition;
                        if (!string.IsNullOrWhiteSpace(_model.CompanyName))
                        {
                            definitionContent = definitionContent.Replace("{{CompanyName}}", _model.CompanyName);
                        }

                        column.Item()
                            .PaddingTop(12)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, definitionContent));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Firme di Offerta e Accettazione.
        /// </summary>
        private void ComposeOfferAcceptanceSignatures(IContainer container, OfferAcceptanceSignatures? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("10. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("10. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Firme di Offerta e Accettazione")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }

                    // Render signature blocks: Company (with image) and Client (signature place only)
                    column.Item()
                        .PaddingTop(20)
                        .PaddingLeft(20)
                        .PaddingRight(20)
                        .Element(c => ComposeSignatureBlocks(c, section));
                });
        }

        /// <summary>
        /// Renders two signature blocks: Company (with image) and Client (signature place only).
        /// </summary>
        private void ComposeSignatureBlocks(
            IContainer container,
            OfferAcceptanceSignatures section)
        {
            byte[]? companySignatureBytes = Base64Helper.ToBytes(section.SignatureSrc);

            container
                .PaddingTop(10)
                .Column(col =>
                {
                    // =========================
                    // COMPANY SIGNATURE
                    // =========================
                    col.Item().Row(row =>
                    {
                        // LEFT: company info
                        row.RelativeItem().Column(left =>
                        {
                            if (!string.IsNullOrWhiteSpace(section.CompanyName))
                            {
                                left.Item()
                                    .Text($"Company: {section.CompanyName}")
                                    .FontSize(11)
                                    .Bold();
                            }

                            if (!string.IsNullOrWhiteSpace(section.NameOfComrecial))
                            {
                                left.Item()
                                    .PaddingTop(2)
                                    .Text($"Name: {section.NameOfComrecial}")
                                    .FontSize(10);
                            }

                            left.Item()
                                .PaddingTop(4)
                                .Text($"Data: {section.CompanySignatureDate:dd.MM.yyyy}")
                                .FontSize(9);
                        });

                        // RIGHT: signature
                        row.ConstantItem(220).Column(right =>
                        {

                            var width = section.SignatureWidth ?? 180;
                            if (companySignatureBytes != null)
                            {
                                right.Item()
            .Width(width)
            .AlignMiddle()
            .Image(companySignatureBytes)
            .FitArea();
                            }
                        });
                    });

                    // spacing
                    col.Item().Height(30);

                    // =========================
                    // CLIENT SIGNATURE
                    // =========================
                    col.Item().Column(client =>
                    {
                        if (!string.IsNullOrWhiteSpace($"Clieant Company: {section.ClieantCompany}"))
                        {
                            client.Item()
                                .Text(section.ClieantCompany)
                                .FontSize(11)
                                .Bold();
                        }

                        client.Item()
                            .PaddingTop(6)
                            .Text("Nome:")
                            .FontSize(10);

                        client.Item()
                            .PaddingTop(2)
                            .Text("Data:")
                            .FontSize(10);

                        client.Item()
                         .Width(180)
                            .PaddingTop(14)
                            .LineHorizontal(1);

                        client.Item()
                            .PaddingTop(4)
                            .Text("Firma")
                            .FontSize(9);
                    });
                });
        }


        /// <summary>
        /// Renders company signature block with image.
        /// </summary>
        private void ComposeCompanySignatureBlock(
            IContainer container,
            OfferAcceptanceSignatures section,
            byte[]? signatureBytes,
            int signatureWidth,
            int signatureHeight)
        {
            container
                .Border(1)
                .BorderColor(ColorBorder)
                .Padding(10)
                .Column(col =>
                {
                    // Title
                    col.Item().Text(section.CompanyName)
                        .FontSize(12)
                        .Bold()
                        .FontColor(ColorPrimary);

                    // Commercial representative name
                    if (!string.IsNullOrWhiteSpace(section.NameOfComrecial))
                    {
                        col.Item().PaddingTop(2).Text(section.NameOfComrecial)
                            .FontSize(10)
                            .FontColor("#555555");
                    }

                    // Separator line
                    col.Item().PaddingTop(8).LineHorizontal(1).LineColor(ColorBorder);

                    // Signature image area
                    col.Item().PaddingTop(6).Height(signatureHeight).AlignLeft().Element(sig =>
                    {
                        if (signatureBytes != null)
                        {
                            sig.Width(signatureWidth)
                                .Height(signatureHeight)
                                .Image(signatureBytes)
                                .FitArea();
                        }
                        else
                        {
                            var placeholder = !string.IsNullOrWhiteSpace(section.SignatureAlt)
                                ? section.SignatureAlt
                                : "Signature not provided";

                            sig.AlignMiddle().Text(placeholder)
                                .FontSize(9)
                                .FontColor("#888888");
                        }
                    });

                    // Company signature date
                    if (section.CompanySignatureDate.HasValue)
                    {
                        col.Item()
                            .PaddingTop(6)
                            .Text($"Date: {section.CompanySignatureDate.Value:yyyy-MM-dd}")
                            .FontSize(9)
                            .FontColor("#666666");
                    }
                });
        }

        /// <summary>
        /// Renders client signature block with signature place (line) only.
        /// </summary>
        private void ComposeClientSignatureBlock(
            IContainer container,
            OfferAcceptanceSignatures section,
            int signatureWidth,
            int signatureHeight)
        {
            container
                .Border(1)
                .BorderColor(ColorBorder)
                .Padding(10)
                .Column(col =>
                {
                    // Title
                    col.Item().Text(section.ClieantName)
                        .FontSize(12)
                        .Bold()
                        .FontColor(ColorPrimary);

                    // Client name
                    if (!string.IsNullOrWhiteSpace(section.ClieantName))
                    {
                        col.Item().PaddingTop(4).Text(section.ClieantName)
                            .FontSize(11)
                            .FontColor(ColorText);
                    }

                    // Separator line
                    col.Item().PaddingTop(8).LineHorizontal(1).LineColor(ColorBorder);

                    // Signature place (empty line for manual signature)
                    col.Item()
                        .PaddingTop(6)
                        .Height(signatureHeight)
                        .Width(signatureWidth)
                        .Border(1)
                        .BorderColor("#cccccc")
                        .Background("#fafafa")
                        .AlignMiddle()
                        .Text("")
                        .FontSize(10)
                        .FontColor("#999999");

                    // Client signature date
                    if (section.ClientSignatureDate.HasValue)
                    {
                        col.Item()
                            .PaddingTop(6)
                            .Text($"Date: {section.ClientSignatureDate.Value:yyyy-MM-dd}")
                            .FontSize(9)
                            .FontColor("#666666");
                    }
                });
        }

        /// <summary>
        /// Compone sezione Costi con tabella prezzi.
        /// </summary>
        private void ComposeAssetOfOfferCosts(IContainer container, AssetOfOfferCosts? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    var isTitleHtml = !string.IsNullOrWhiteSpace(section.Title) &&
                                      section.Title.Contains('<') && section.Title.Contains('>');

                    column.Item()
                        .PreventPageBreak()
                        .PaddingBottom(8)
                        .Row(row =>
                        {
                            row.ConstantItem(5)
                                .Background("#000080")
                                .Height(35);

                            row.RelativeItem()
                                .PaddingLeft(15)
                                .AlignMiddle()
                                .Text(text =>
                                {
                                    text.Span("4. ")
                                        .FontSize(16)
                                        .FontColor(ColorSecondary)
                                        .Bold();

                                    if (!isTitleHtml && !string.IsNullOrWhiteSpace(section.Title))
                                    {
                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    }
                                    else
                                    {
                                        text.Span("Costi")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    }
                                });
                        });


                    if (isTitleHtml && !string.IsNullOrWhiteSpace(section.Title))
                    {
                        var titleContent = section.Title;
                        if (section.Year.HasValue)
                        {
                            titleContent = titleContent.Replace("{{Year}}", section.Year.Value.ToString());
                        }

                        if (!string.IsNullOrWhiteSpace(titleContent))
                        {
                            column.Item()
                                .PaddingTop(12)
                                .PaddingBottom(8)
                                .PaddingLeft(20)
                                .PaddingRight(20)
                                .Element(c => _htmlRenderer.ComposeHtmlContent(c, titleContent));
                        }
                    }

                    if (section.TableAssetOfOffer?.Any() == true)
                    {
                        column.Item()
                            .PaddingTop(20)
                            .Element(c => ComposePricingTable(
                                c,
                                section.TableAssetOfOffer,
                                section.TotalListPrice,
                                section.DiscountedListPrice,
                                section.TotalPriceScount, // TotaleDaPagare (final total after discount)
                                section.TotalAnnualFee,
                                section.DiscountOnAnnualFee,
                                section.TotalCannonScount, // TotaleCanoneAnnualeDaPagare (final fee after discount)
                                section.ListPriceDiscountPercentage,
                                section.AnnualFeeDiscountPercentage));
                    }

                    if (!string.IsNullOrWhiteSpace(section.DiscountTitle))
                    {
                        var discountContent = section.DiscountTitle;
                        if (section.Year.HasValue)
                        {
                            discountContent = discountContent.Replace("{{Year}}", section.Year.Value.ToString());
                        }

                        if (!string.IsNullOrWhiteSpace(discountContent))
                        {
                            column.Item()
                                .PaddingTop(15)
                                .PaddingLeft(20)
                                .PaddingRight(20)
                                .Element(c => _htmlRenderer.ComposeHtmlContent(c, discountContent));
                        }
                    }
                });
        }

        /// <summary>
        /// Compone sezione Consegna.
        /// </summary>
        private void ComposeDelivery(IContainer container, Delivery? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("5. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("5. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Consegna")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Installazione ed Istruzione.
        /// </summary>
        private void ComposeInstallationAndInstruction(IContainer container, InstallationAndInstruction? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("6. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("6. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Installazione ed Istruzione")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone sezione Condizioni di Pagamento.
        /// </summary>
        private void ComposePaymentConditions(IContainer container, PaymentConditions? section)
        {
            if (section == null) return;

            container
                .EnsureSpace(100)
                .PaddingTop(25)
                .Column(column =>
                {
                    if (!string.IsNullOrWhiteSpace(section.Title))
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("7. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span(section.Title)
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }
                    else
                    {
                        column.Item()
                            .PreventPageBreak()
                            .PaddingBottom(8)
                            .Row(row =>
                            {
                                row.ConstantItem(5)
                                    .Background("#000080")
                                    .Height(35);

                                row.RelativeItem()
                                    .PaddingLeft(15)
                                    .AlignMiddle()
                                    .Text(text =>
                                    {
                                        text.Span("7. ")
                                            .FontSize(16)
                                            .FontColor(ColorSecondary)
                                            .Bold();

                                        text.Span("Condizioni di Pagamento")
                                            .FontSize(18)
                                            .FontColor(ColorPrimary)
                                            .Bold();
                                    });
                            });
                    }

                    if (!string.IsNullOrWhiteSpace(section.Definition))
                    {
                        column.Item()
                            .PaddingTop(12)
                            .PaddingBottom(4)
                            .PaddingLeft(20)
                            .PaddingRight(20)
                            .Element(c => _htmlRenderer.ComposeHtmlContent(c, section.Definition));
                    }
                });
        }

        /// <summary>
        /// Compone la tabella dei prezzi con prodotti, quantità, prezzi e totali.
        /// Mostra i totali lordi, gli sconti (se presenti) e i totali finali dopo gli sconti.
        /// </summary>
        private void ComposePricingTable(
            IContainer container,
            List<TableAssetOfOffer> items,
            decimal? totalListPrice = null,
            decimal? discountedListPrice = null,
            decimal? totalToBePaid = null,
            decimal? totalAnnualFee = null,
            decimal? discountOnAnnualFee = null,
            decimal? totalAnnualFeeToBePaid = null,
            int? listPriceDiscountPercentage = null,
            int? annualFeeDiscountPercentage = null)
        {
            var headerBg = "#6f8fb9";
            var rowBg1 = "#3e5873";
            var rowBg2 = "#465f7a";
            var textColor = Colors.White;
            var finalTotalBg = "#7a9bc4"; // Sfondo più chiaro per totali finali (come mostrato nello screenshot)

            container.Table(table =>
            {
                // ===== COLUMN DEFINITIONS =====
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(5);   // Modulo (wide column)
                    columns.ConstantColumn(60);  // Quantità
                    columns.ConstantColumn(90);  // Prezzo
                    columns.ConstantColumn(90);  // Canone
                });

                // ===== HEADER =====
                table.Header(header =>
                {
                    IContainer HeaderCell(IContainer c) => c
                        .Background(headerBg)
                        .PaddingVertical(3)
                        .PaddingHorizontal(6)
                        .BorderColor(Colors.Black)
                        .AlignMiddle();

                    header.Cell().Element(HeaderCell)
                        .Text("modulo")
                        .FontColor(textColor)
                        .FontSize(12)
                        .Bold()
                        .Italic();

                    header.Cell().Element(HeaderCell).AlignCenter()
                        .Text("quantità")
                        .FontColor(textColor)
                        .FontSize(12)
                        .Bold()
                        .Italic();

                    header.Cell().Element(HeaderCell).AlignRight()
                        .Text("prezzo (1)")
                        .FontColor(textColor)
                        .FontSize(12)
                        .Bold()
                        .Italic();

                    header.Cell().Element(HeaderCell).AlignRight()
                        .Text("canone (2)")
                        .FontColor(textColor)
                        .FontSize(12)
                        .Bold()
                        .Italic();
                });

                // ===== DATA ROWS =====
                var index = 1;
                foreach (var item in items.OrderBy(x => x.OrderIndex ?? int.MaxValue))
                {
                    var bgColor = index % 2 == 0 ? rowBg2 : rowBg1;

                    IContainer DataCell(IContainer c) => c
                        .Background(bgColor)
                        .PaddingVertical(3)
                        .PaddingHorizontal(6)
                        .BorderColor(Colors.Black);

                    table.Cell().Element(DataCell)
                        .Text(item.Module ?? "")
                        .FontColor(textColor)
                        .FontSize(10);

                    var quantity = item.Quantity ?? 1m;
                    table.Cell().Element(DataCell).AlignCenter()
                        .Text(quantity.ToString("N0"))
                        .FontColor(textColor)
                        .FontSize(10);

           
                    var itemPrice = item.TotalPrice ?? (item.Price * quantity);
                    var showPrice = item.TotalPrice.HasValue ? item.TotalPrice.Value != 0 : item.Price != 0;
                    
                    if (showPrice)
                    {
                        table.Cell().Element(DataCell).AlignRight()
                            .Text($"€ {itemPrice:N2}")
                            .FontColor(textColor)
                            .FontSize(10);
                    }
                    else
                    {
                        table.Cell().Element(DataCell).AlignRight()
                            .Text("")
                            .FontColor(textColor)
                            .FontSize(10);
                    }

                  
                    var itemCannon = item.TotalCannon ?? item.Cannon;
                    var showCannon = item.TotalCannon.HasValue ? item.TotalCannon.Value != 0 : item.Cannon != 0;
                    
                    if (showCannon)
                    {
                        table.Cell().Element(DataCell).AlignRight()
                            .Text($"€ {itemCannon:N2}")
                            .FontColor(textColor)
                            .FontSize(10);
                    }
                    else
                    {
                        table.Cell().Element(DataCell).AlignRight()
                            .Text("")
                            .FontColor(textColor)
                            .FontSize(10);
                    }

                    index++;
                }

                // ===== CALCULATE TOTALS =====
                // Calculate gross totals (before discounts)


                var calculatedTotalPrice = totalListPrice ?? items.Sum(x =>
                    x.TotalPrice ?? (x.Price * (x.Quantity ?? 1m)));

                var calculatedTotalCannon = totalAnnualFee ?? items.Sum(x =>
                    x.TotalCannon ?? x.Cannon);

                var grossTotalPrice = totalListPrice ?? calculatedTotalPrice;
                var grossTotalCannon = totalAnnualFee ?? calculatedTotalCannon;

                // Calcola gli importi dello sconto
                // discountedListPrice è L'IMPORTO DELLO SCONTO (non il prezzo finale)
                // Se non fornito, calcola dalla percentuale
                decimal? actualDiscountAmount = discountedListPrice;
                if (!actualDiscountAmount.HasValue && listPriceDiscountPercentage.HasValue && grossTotalPrice > 0)
                {
                    actualDiscountAmount = grossTotalPrice * (listPriceDiscountPercentage.Value / 100m);
                }

                // Calcola i totali finali (dopo gli sconti)
                var finalTotalPrice = totalToBePaid ?? (grossTotalPrice - (actualDiscountAmount ?? 0m));
                var finalTotalCannon = totalAnnualFeeToBePaid ?? (grossTotalCannon - (discountOnAnnualFee ?? 0m));

                // Verifica se ci sono sconti da visualizzare
                var hasListPriceDiscount = actualDiscountAmount.HasValue && actualDiscountAmount.Value > 0;
                var hasAnnualFeeDiscount = discountOnAnnualFee.HasValue && discountOnAnnualFee.Value > 0;
                var hasAnyDiscount = hasListPriceDiscount || hasAnnualFeeDiscount;

                // ===== STYLE DEFINITIONS =====
                IContainer TotalCell(IContainer c) => c
                    .Background(headerBg)
                    .PaddingVertical(4)
                    .PaddingHorizontal(6)
                    .BorderColor(Colors.Black);

                IContainer FinalTotalCell(IContainer c) => c
                    .Background(finalTotalBg)
                    .PaddingVertical(4)
                    .PaddingHorizontal(6)
                    .BorderColor(Colors.Black);

                // ===== GROSS TOTALS (Totale lordo) =====
                table.Cell().ColumnSpan(2).Element(TotalCell)
                    .Text("Totale lordo")
                    .FontColor(textColor)
                    .FontSize(12)
                    .Bold();

                table.Cell().Element(TotalCell).AlignRight()
                    .Text($"€ {grossTotalPrice:N2}")
                    .FontColor(textColor)
                    .FontSize(10)
                    .Bold();

                table.Cell().Element(TotalCell).AlignRight()
                    .Text($"€ {grossTotalCannon:N2}")
                    .FontColor(textColor)
                    .FontSize(10)
                    .Bold();

                // ===== DISCOUNTS (only if they exist) =====
                if (hasAnyDiscount)
                {
                    // Totale canone lordo (if there's a discount on annual fee)
                    if (hasAnnualFeeDiscount)
                    {
                        table.Cell().ColumnSpan(2).Element(TotalCell)
                            .Text("Totale canone lordo")
                            .FontColor(textColor)
                            .FontSize(12)
                            .Bold();

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text("")
                            .FontColor(textColor)
                            .FontSize(10);

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text($"€ {grossTotalCannon:N2}")
                            .FontColor(textColor)
                            .FontSize(10)
                            .Bold();
                    }

                    // Sconto sul totale (discount on total price)
                    if (hasListPriceDiscount)
                    {
                        var discountPercentText = listPriceDiscountPercentage.HasValue
                            ? $" ({listPriceDiscountPercentage.Value}%)"
                            : "";

                        table.Cell().ColumnSpan(2).Element(TotalCell)
                            .Text($"Sconto sul totale{discountPercentText}")
                            .FontColor(textColor)
                            .FontSize(10)
                            .Bold();

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text($"€ {actualDiscountAmount!.Value:N2}")
                            .FontColor(textColor)
                            .FontSize(10)
                            .Bold();

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text("")
                            .FontColor(textColor)
                            .FontSize(10);
                    }

                    // Sconto sul canone (discount on annual fee)
                    if (hasAnnualFeeDiscount)
                    {
                        var discountPercentText = annualFeeDiscountPercentage.HasValue
                            ? $" ({annualFeeDiscountPercentage.Value}%)"
                            : "";

                        table.Cell().ColumnSpan(2).Element(TotalCell)
                            .Text($"Sconto sul canone{discountPercentText}")
                            .FontColor(textColor)
                            .FontSize(10)
                            .Bold();

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text("")
                            .FontColor(textColor)
                            .FontSize(10);

                        table.Cell().Element(TotalCell).AlignRight()
                            .Text($"€ {discountOnAnnualFee!.Value:N2}")
                            .FontColor(textColor)
                            .FontSize(10)
                            .Bold();
                    }

                    // ===== SEPARATOR LINE =====
                    table.Cell().ColumnSpan(4).Element(c => c
                        .Height(1)
                        .Background(Colors.Black)
                        .BorderColor(Colors.Black));
                }

                // ===== FINAL TOTALS (after discounts) =====
                table.Cell().ColumnSpan(2).Element(FinalTotalCell)
                    .Text("Totale")
                    .FontColor(textColor)
                    .FontSize(12)
                    .Bold();

                table.Cell().Element(FinalTotalCell).AlignRight()
                    .Text($"€ {finalTotalPrice:N2}")
                    .FontColor(textColor)
                    .FontSize(10)
                    .Bold();

                table.Cell().Element(FinalTotalCell).AlignRight()
                    .Text($"€ {finalTotalCannon:N2}")
                    .FontColor(textColor)
                    .FontSize(10)
                    .Bold();
            });
        }


        /// <summary>
        /// Compone la lista dei prodotti con le loro descrizioni.
        /// </summary>
        private void ComposeProductList(IContainer container, List<ProductDescription> products)
        {
            container.Column(column =>
            {
                foreach (var product in products.OrderBy(p => p.OrderIndex ?? int.MaxValue).ThenBy(p => p.PositionIndex ?? int.MaxValue))
                {
                    column.Item().PaddingBottom(10)
                        .Background(Colors.Grey.Lighten4)
                        .Border(1).BorderColor(ColorBorder)
                        .Padding(15)
                        .Column(productColumn =>
                        {
                            if (!string.IsNullOrWhiteSpace(product.ProductName))
                            {
                                var productNameRenderer = new HtmlToPdfRenderer(
                                    defaultFontSize: 12f,
                                    defaultTextColor: ColorSecondary
                                );

                                productColumn.Item()
                                    .Element(c => productNameRenderer.ComposeHtmlContent(c, product.ProductName));
                            }

                            if (!string.IsNullOrWhiteSpace(product.Title))
                            {
                                var titleRenderer = new HtmlToPdfRenderer(
                                    defaultFontSize: 11f,
                                    defaultTextColor: ColorText
                                );

                                productColumn.Item()
                                    .PaddingTop(5)
                                    .Element(c => titleRenderer.ComposeHtmlContent(c, product.Title));
                            }

                            if (!string.IsNullOrWhiteSpace(product.Description))
                            {
                                var descriptionRenderer = new HtmlToPdfRenderer(
                                    defaultFontSize: 11f,
                                    defaultTextColor: ColorText
                                );

                                productColumn.Item()
                                    .PaddingTop(10)
                                    .PaddingBottom(5)
                                    .Element(c => descriptionRenderer.ComposeHtmlContent(c, product.Description));
                            }
                        });
                }
            });
        }

        #endregion

        #region METODI - Utility

        private string StripHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            var cleaned = System.Text.RegularExpressions.Regex
                .Replace(html, "<.*?>", string.Empty);

            cleaned = cleaned
                .Replace("&nbsp;", " ")
                .Replace("&amp;", "&")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&quot;", "\"")
                .Replace("&#39;", "'")
                .Trim();

            return cleaned;
        }

        #endregion
    }
}
