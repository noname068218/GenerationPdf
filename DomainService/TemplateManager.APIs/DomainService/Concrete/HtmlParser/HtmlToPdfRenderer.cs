using HtmlAgilityPack;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.DomainService
{

    /// <summary>
    /// Converte contenuto HTML in testo formattato per QuestPDF.
    /// Gestisce HTML complesso da Quill Editor con stili, liste e formattazione.
    /// </summary>
    internal class HtmlToPdfRenderer
    {
        #region FIELDS

        private readonly float DefaultFontSize = 11f;
        private readonly string DefaultTextColor = "#333333";
        private int _orderedListCounter = 0;
        private int _orderedListLevel = 0;
        private int _currentIndentLevel = 0;

        #endregion

        #region CONSTRUCTORS

        public HtmlToPdfRenderer()
        {
        }

        public HtmlToPdfRenderer(float defaultFontSize, string defaultTextColor)
        {
            DefaultFontSize = defaultFontSize;
            DefaultTextColor = defaultTextColor;
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Compone contenuto HTML nel container QuestPDF con formattazione.
        /// </summary>
        public void ComposeHtmlContent(IContainer container, string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return;

            _orderedListCounter = 0;
            _orderedListLevel = 0;
            _currentIndentLevel = 0;

            // Don't set default text style here to allow HTML styles to take precedence
            // The HTML will set its own styles through inline styles
            container.Text(text =>
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                RenderHtmlNode(text, doc.DocumentNode);
            });
        }

        /// <summary>
        /// Rimuove tag HTML e restituisce testo pulito.
        /// </summary>
        public string StripHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode.InnerText
                .Replace("&nbsp;", " ")
                .Replace("&amp;", "&")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&quot;", "\"")
                .Replace("&#39;", "'")
                .Trim();
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Renderizza ricorsivamente i nodi HTML con formattazione.
        /// </summary>
        private void RenderHtmlNode(TextDescriptor text, HtmlNode node)
        {
            foreach (var child in node.ChildNodes)
            {
                if (child.NodeType == HtmlNodeType.Text)
                {

                    var textContent = child.InnerText;
                    if (!string.IsNullOrWhiteSpace(textContent))
                    {
                        text.Span(textContent)
                            .FontSize(DefaultFontSize)
                            .FontColor(DefaultTextColor);
                    }
                }
                else if (child.NodeType == HtmlNodeType.Element)
                {
                    var tagName = child.Name.ToLower();
                    var style = child.GetAttributeValue("style", "");
                    var color = ExtractColorFromStyle(style);

                    switch (tagName)
                    {
                        case "p":
                            var hasContent = child.ChildNodes.Any(n =>
                            {
                                if (n.NodeType == HtmlNodeType.Text)
                                    return !string.IsNullOrWhiteSpace(n.InnerText);
                                if (n.NodeType == HtmlNodeType.Element)
                                {
                                    var childTag = n.Name.ToLower();
                                    return childTag != "br" && !n.HasClass("ql-ui");
                                }
                                return false;
                            });

                            if (hasContent)
                            {
                                var pClass = child.GetAttributeValue("class", "");
                                var pStyle = child.GetAttributeValue("style", "");


                                var marginBottom = ExtractMarginBottomFromStyle(pStyle);
                                var lineHeight = ExtractLineHeightFromStyle(pStyle);
                                var fontWeight = ExtractFontWeightFromStyle(pStyle);
                                var pFontSize = ExtractFontSizeFromStyle(pStyle) ?? DefaultFontSize;
                                var pColor = ExtractColorFromStyle(pStyle) ?? DefaultTextColor;

                                var significantElements = child.ChildNodes
                                    .Where(n => n.NodeType == HtmlNodeType.Element &&
                                               !n.HasClass("ql-ui") &&
                                               n.Name.ToLower() != "br")
                                    .ToList();

                                var isHeadingParagraph = significantElements.Count == 1 &&
                                                         (significantElements[0].Name.ToLower() == "strong" ||
                                                          significantElements[0].Name.ToLower() == "b" ||
                                                          significantElements[0].Name.ToLower() == "u");

                                // Apply paragraph-level styles
                                text.DefaultTextStyle(ts =>
                                {
                                    var style = ts;
                                    if (lineHeight.HasValue)
                                        style = style.LineHeight(lineHeight.Value);
                                    if (pFontSize != DefaultFontSize)
                                        style = style.FontSize(pFontSize);
                                    if (pColor != DefaultTextColor)
                                        style = style.FontColor(Color.FromHex(pColor));
                                    if (fontWeight >= 600)
                                        style = style.Bold();
                                    return style;
                                });

                                RenderHtmlNode(text, child);


                                text.DefaultTextStyle(ts => ts
                                    .LineHeight(1.5f)
                                    .FontSize(DefaultFontSize)
                                    .FontColor(DefaultTextColor));


                                if (marginBottom > 0)
                                {

                                    var breaks = marginBottom > 15 ? "\n\n" : "\n";
                                    text.Span(breaks);
                                }
                                else if (isHeadingParagraph)
                                {
                                    text.Span("\n\n");
                                }
                                else
                                {
                                    text.Span("\n");
                                }
                            }
                            break;

                        case "br":
                            text.Span("\n");
                            break;

                        case "strong":
                        case "b":

                            RenderTextWithStyle(text, child, isBold: true, color: color);
                            break;

                        case "em":
                        case "i":

                            RenderTextWithStyle(text, child, isItalic: true, color: color);
                            break;

                        case "u":
                            RenderTextWithStyle(text, child, isUnderline: true, color: color);
                            break;

                        case "span":

                            if (child.HasClass("ql-ui"))
                            {

                                continue;
                            }
                            RenderTextWithStyle(text, child, color: color);
                            break;

                        case "ol":
                            _orderedListLevel++;
                            var savedCounter = _orderedListCounter;
                            _orderedListCounter = 0;
                            RenderHtmlNode(text, child);
                            _orderedListCounter = savedCounter;
                            _orderedListLevel--;
                            break;

                        case "ul":

                            var listStyle = child.GetAttributeValue("style", "");
                            var listMarginBottom = ExtractMarginBottomFromStyle(listStyle);

                            RenderHtmlNode(text, child);


                            if (listMarginBottom > 0)
                            {
                                text.Span("\n");
                            }
                            break;

                        case "li":
                            var parentTag = child.ParentNode?.Name.ToLower() ?? "";
                            var dataList = child.GetAttributeValue("data-list", "");
                            var liStyle = child.GetAttributeValue("style", "");

                            var indentLevel = 0;
                            var classAttr = child.GetAttributeValue("class", "");
                            if (!string.IsNullOrWhiteSpace(classAttr))
                            {
                                var indentMatch = System.Text.RegularExpressions.Regex.Match(
                                    classAttr,
                                    @"ql-indent-(\d+)",
                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                if (indentMatch.Success && int.TryParse(indentMatch.Groups[1].Value, out int indent))
                                {
                                    indentLevel = indent;
                                }
                            }


                            var liMarginBottom = ExtractMarginBottomFromStyle(liStyle);
                            var liLineHeight = ExtractLineHeightFromStyle(liStyle);
                            var liColor = ExtractColorFromStyle(liStyle);
                            var liPaddingLeft = ExtractPaddingLeftFromStyle(liStyle);

                            var indentSpaces = new string(' ', indentLevel * 4 + (liPaddingLeft > 0 ? (int)(liPaddingLeft / 4) : 0));

                            bool isOrdered = parentTag == "ol" || dataList == "ordered";


                            var parentUl = child.ParentNode;
                            var listStyleType = "disc";
                            if (parentUl != null)
                            {
                                var ulStyle = parentUl.GetAttributeValue("style", "");
                                var listStyleMatch = System.Text.RegularExpressions.Regex.Match(
                                    ulStyle,
                                    @"list-style-type\s*:\s*([^;]+)",
                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                if (listStyleMatch.Success)
                                {
                                    listStyleType = listStyleMatch.Groups[1].Value.Trim().ToLower();
                                }
                            }

                            if (isOrdered)
                            {
                                _orderedListCounter++;
                                var listMarker = $"{indentSpaces}{_orderedListCounter}. ";
                                text.Span(listMarker)
                                    .FontSize(DefaultFontSize)
                                    .FontColor(liColor ?? "#1e3a5f")
                                    .Bold();
                            }
                            else
                            {

                                var marker = listStyleType switch
                                {
                                    "square" => "▪ ",
                                    "circle" => "○ ",
                                    "disc" => "• ",
                                    _ => "• "
                                };
                                var listMarker = $"{indentSpaces}{marker}";
                                text.Span(listMarker)
                                    .FontSize(DefaultFontSize)
                                    .FontColor(liColor ?? "#1e3a5f")
                                    .Bold();
                            }


                            if (liLineHeight.HasValue)
                            {
                                text.DefaultTextStyle(ts => ts.LineHeight(liLineHeight.Value));
                            }

                            RenderHtmlNode(text, child);


                            if (liLineHeight.HasValue)
                            {
                                text.DefaultTextStyle(ts => ts.LineHeight(1.5f));
                            }

                            var firstTextNode = child.ChildNodes
                                .FirstOrDefault(n => n.NodeType == HtmlNodeType.Element &&
                                                    !n.HasClass("ql-ui") &&
                                                    (n.Name.ToLower() == "u" || n.Name.ToLower() == "strong" || n.Name.ToLower() == "b"));

                            if (firstTextNode != null && indentLevel == 0)
                            {
                                text.Span("\n");
                            }

                            if (liMarginBottom > 0)
                            {
                                text.Span("\n");
                            }
                            else
                            {
                                text.Span("\n");
                            }
                            break;

                        case "h1":
                        case "h2":
                        case "h3":
                        case "h4":
                        case "h5":
                        case "h6":
                            var headingSize = tagName switch
                            {
                                "h1" => DefaultFontSize + 6,
                                "h2" => DefaultFontSize + 5,
                                "h3" => DefaultFontSize + 4,
                                "h4" => DefaultFontSize + 3,
                                "h5" => DefaultFontSize + 2,
                                "h6" => DefaultFontSize + 1,
                                _ => DefaultFontSize + 3
                            };

                            var styleFontSize = ExtractFontSizeFromStyle(style);
                            if (styleFontSize.HasValue)
                            {
                                headingSize = styleFontSize.Value;
                            }

                            var headingFontWeight = ExtractFontWeightFromStyle(style);
                            var headingMarginTop = ExtractMarginTopFromStyle(style);
                            var headingMarginBottom = ExtractMarginBottomFromStyle(style);
                            var headingLineHeight = ExtractLineHeightFromStyle(style);
                            var headingPaddingBottom = ExtractPaddingBottomFromStyle(style);
                            var borderBottomColor = ExtractBorderBottomColor(style);
                            var hasBorderBottom = !string.IsNullOrWhiteSpace(borderBottomColor);


                            if (headingMarginTop > 0)
                            {
                                text.Span("\n");
                            }

                            text.Span("\n");


                            text.DefaultTextStyle(ts =>
                            {
                                var style = ts.FontSize(headingSize);
                                if (headingLineHeight.HasValue)
                                    style = style.LineHeight(headingLineHeight.Value);
                                if (headingFontWeight >= 600 || headingFontWeight == 0)
                                    style = style.Bold();
                                return style;
                            });

                            RenderTextWithStyle(text, child,
                                isBold: headingFontWeight >= 600 || headingFontWeight == 0,
                                color: color ?? "#1e3a5f",
                                fontSize: headingSize);


                            text.DefaultTextStyle(ts => ts
                                .LineHeight(1.5f)
                                .FontSize(DefaultFontSize)
                                .FontColor(DefaultTextColor));


                            if (hasBorderBottom)
                            {
                                text.Span("\n");

                                var borderColor = borderBottomColor ?? color ?? "#2d3748";
                                text.Span(new string('─', 40))
                                    .FontSize(8)
                                    .FontColor(borderColor);
                            }


                            if (headingPaddingBottom > 0)
                            {
                                text.Span("\n");
                            }


                            if (headingMarginBottom > 0)
                            {
                                var breaks = headingMarginBottom > 15 ? "\n\n" : "\n";
                                text.Span(breaks);
                            }
                            else
                            {
                                text.Span("\n");
                            }
                            break;

                        case "mark":
                            RenderTextWithStyle(text, child, color: color ?? "#856404");
                            break;

                        case "code":
                            var codeContent = child.InnerText;
                            if (!string.IsNullOrWhiteSpace(codeContent))
                            {
                                text.Span(codeContent)
                                    .FontSize(DefaultFontSize - 1)
                                    .FontColor(color ?? "#d63384");
                            }
                            else
                            {
                                RenderHtmlNode(text, child);
                            }
                            break;

                        case "blockquote":
                            text.Span("\n");
                            RenderHtmlNode(text, child);
                            text.Span("\n");
                            break;

                        case "div":

                            var divStyle = child.GetAttributeValue("style", "");
                            var divLineHeight = ExtractLineHeightFromStyle(divStyle);
                            var divFontSize = ExtractFontSizeFromStyle(divStyle);
                            var divColor = ExtractColorFromStyle(divStyle);

                            if (divLineHeight.HasValue || divFontSize.HasValue || divColor != null)
                            {
                                text.DefaultTextStyle(ts =>
                                {
                                    var style = ts;
                                    if (divLineHeight.HasValue)
                                        style = style.LineHeight(divLineHeight.Value);
                                    if (divFontSize.HasValue)
                                        style = style.FontSize(divFontSize.Value);
                                    if (divColor != null)
                                        style = style.FontColor(Color.FromHex(divColor));
                                    return style;
                                });
                            }

                            RenderHtmlNode(text, child);

                            if (divLineHeight.HasValue || divFontSize.HasValue || divColor != null)
                            {
                                text.DefaultTextStyle(ts => ts
                                    .LineHeight(1.5f)
                                    .FontSize(DefaultFontSize)
                                    .FontColor(DefaultTextColor));
                            }
                            break;

                        default:
                            RenderHtmlNode(text, child);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Renderizza testo con formattazione (grassetto, corsivo, sottolineato, colore, dimensione).
        /// </summary>
        private void RenderTextWithStyle(
            TextDescriptor text,
            HtmlNode node,
            bool isBold = false,
            bool isItalic = false,
            bool isUnderline = false,
            string? color = null,
            float? fontSize = null)
        {

            var textContent = node.InnerText;


            if (node.HasChildNodes && node.ChildNodes.Any(n => n.NodeType == HtmlNodeType.Element))
            {

                foreach (var child in node.ChildNodes)
                {
                    if (child.NodeType == HtmlNodeType.Text)
                    {
                        RenderStyledSpan(text, child.InnerText, isBold, isItalic, isUnderline, color, fontSize);
                    }
                    else if (child.NodeType == HtmlNodeType.Element)
                    {

                        var childStyle = child.GetAttributeValue("style", "");
                        var childColor = ExtractColorFromStyle(childStyle);
                        var childFontSize = ExtractFontSizeFromStyle(childStyle) ?? fontSize;
                        var childTag = child.Name.ToLower();

                        var childBold = isBold || childTag == "strong" || childTag == "b";
                        var childItalic = isItalic || childTag == "em" || childTag == "i";
                        var childUnderline = isUnderline || childTag == "u";
                        var finalColor = childColor ?? color;

                        RenderTextWithStyle(text, child, childBold, childItalic, childUnderline, finalColor, childFontSize);
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(textContent))
            {

                RenderStyledSpan(text, textContent, isBold, isItalic, isUnderline, color, fontSize);
            }
        }

        /// <summary>
        /// Renderizza uno span di testo con stile specificato.
        /// </summary>
        private void RenderStyledSpan(
            TextDescriptor text,
            string content,
            bool isBold,
            bool isItalic,
            bool isUnderline,
            string? color,
            float? fontSize = null)
        {
            if (string.IsNullOrWhiteSpace(content))
                return;

            var span = text.Span(content);

            if (isBold)
                span.Bold();
            if (isItalic)
                span.Italic();
            if (isUnderline)
                span.Underline();

            if (!string.IsNullOrWhiteSpace(color))
            {
                try
                {
                    span.FontColor(Color.FromHex(color));
                }
                catch
                {
                    span.FontColor(DefaultTextColor);
                }
            }
            else
            {
                span.FontColor(DefaultTextColor);
            }

            span.FontSize(fontSize ?? DefaultFontSize);
        }

        /// <summary>
        /// Estrae dimensione font dall'attributo style inline.
        /// </summary>
        private float? ExtractFontSizeFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return null;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"font-size\s*:\s*(\d+(?:\.\d+)?)\s*px",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success && float.TryParse(match.Groups[1].Value, out float fontSize))
            {
                return fontSize;
            }

            return null;
        }

        /// <summary>
        /// Estrae colore dall'attributo style inline.
        /// </summary>
        private string? ExtractColorFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return null;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"color\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                var colorValue = match.Groups[1].Value.Trim();

                if (colorValue.StartsWith("#"))
                    return colorValue;

                var rgbMatch = System.Text.RegularExpressions.Regex.Match(
                    colorValue,
                    @"rgba?\((\d+)\s*,\s*(\d+)\s*,\s*(\d+)(?:\s*,\s*[\d.]+)?\)",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                if (rgbMatch.Success)
                {
                    var r = int.Parse(rgbMatch.Groups[1].Value);
                    var g = int.Parse(rgbMatch.Groups[2].Value);
                    var b = int.Parse(rgbMatch.Groups[3].Value);
                    return $"#{r:X2}{g:X2}{b:X2}";
                }

                return colorValue.ToLower() switch
                {
                    "navy" => "#000080",
                    "black" => "#000000",
                    "blue" => "#0000FF",
                    "red" => "#FF0000",
                    "green" => "#008000",
                    "white" => "#FFFFFF",
                    "gray" => "#808080",
                    "grey" => "#808080",
                    "silver" => "#C0C0C0",
                    "maroon" => "#800000",
                    "purple" => "#800080",
                    "fuchsia" => "#FF00FF",
                    "lime" => "#00FF00",
                    "olive" => "#808000",
                    "yellow" => "#FFFF00",
                    "teal" => "#008080",
                    "aqua" => "#00FFFF",
                    _ => null
                };
            }

            return null;
        }

        /// <summary>
        /// Estrae font-weight dall'attributo style.
        /// </summary>
        private int ExtractFontWeightFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"font-weight\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                var weightValue = match.Groups[1].Value.Trim().ToLower();

                return weightValue switch
                {
                    "normal" => 400,
                    "bold" => 700,
                    "bolder" => 700,
                    "lighter" => 300,
                    _ => int.TryParse(weightValue, out int weight) ? weight : 0
                };
            }

            return 0;
        }

        /// <summary>
        /// Estrae line-height dall'attributo style.
        /// </summary>
        private float? ExtractLineHeightFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return null;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"line-height\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                var lineHeightValue = match.Groups[1].Value.Trim();

                // Remove 'px' if present and try to parse as float
                lineHeightValue = lineHeightValue.Replace("px", "").Trim();

                if (float.TryParse(lineHeightValue, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out float lineHeight))
                {
                    return lineHeight;
                }
            }

            return null;
        }

        /// <summary>
        /// Estrae margin-bottom dall'attributo style.
        /// </summary>
        private float ExtractMarginBottomFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"margin-bottom\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ParseSize(match.Groups[1].Value.Trim());
            }

            return 0;
        }

        /// <summary>
        /// Estrae margin-top dall'attributo style.
        /// </summary>
        private float ExtractMarginTopFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"margin-top\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ParseSize(match.Groups[1].Value.Trim());
            }

            return 0;
        }

        /// <summary>
        /// Estrae padding-left dall'attributo style.
        /// </summary>
        private float ExtractPaddingLeftFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"padding-left\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ParseSize(match.Groups[1].Value.Trim());
            }

            return 0;
        }

        /// <summary>
        /// Converte una dimensione CSS (px) in float.
        /// </summary>
        private float ParseSize(string sizeValue)
        {
            if (string.IsNullOrWhiteSpace(sizeValue))
                return 0;

            sizeValue = sizeValue.Trim().ToLower().Replace("px", "").Replace("pt", "");

            if (float.TryParse(sizeValue, System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out float result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// Estrae padding-bottom dall'attributo style.
        /// </summary>
        private float ExtractPaddingBottomFromStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"padding-bottom\s*:\s*([^;]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ParseSize(match.Groups[1].Value.Trim());
            }

            return 0;
        }

        /// <summary>
        /// Estrae il colore del border-bottom dall'attributo style.
        /// Esempio: "border-bottom:2px solid #2d3748" -> "#2d3748"
        /// </summary>
        private string? ExtractBorderBottomColor(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return null;

            // Match patterns like: border-bottom: 2px solid #2d3748
            var match = System.Text.RegularExpressions.Regex.Match(
                style,
                @"border-bottom\s*:\s*[^;]*?(#[0-9a-fA-F]{3,6}|rgba?\([^)]+\)|[a-z]+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success && match.Groups.Count > 1)
            {
                var colorValue = match.Groups[1].Value.Trim();

                // Handle hex colors
                if (colorValue.StartsWith("#"))
                    return colorValue;

                // Handle rgb/rgba colors
                var rgbMatch = System.Text.RegularExpressions.Regex.Match(
                    colorValue,
                    @"rgba?\((\d+)\s*,\s*(\d+)\s*,\s*(\d+)(?:\s*,\s*[\d.]+)?\)",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                if (rgbMatch.Success)
                {
                    var r = int.Parse(rgbMatch.Groups[1].Value);
                    var g = int.Parse(rgbMatch.Groups[2].Value);
                    var b = int.Parse(rgbMatch.Groups[3].Value);
                    return $"#{r:X2}{g:X2}{b:X2}";
                }

                // Handle named colors
                return colorValue.ToLower() switch
                {
                    "black" => "#000000",
                    "navy" => "#000080",
                    "blue" => "#0000FF",
                    "red" => "#FF0000",
                    "gray" => "#808080",
                    "grey" => "#808080",
                    _ => null
                };
            }

            return null;
        }

        #endregion
    }
}
