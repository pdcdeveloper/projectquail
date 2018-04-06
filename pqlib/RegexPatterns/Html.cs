namespace pqlib.RegexPatterns
{
    // <see cref="http://www.w3schools.com/"/>
    // <see cref="http://www.w3schools.com/tags/"/>
    public static class Html
    {
        public const string BreakTag = @"<br />";
        public const string BreakTagAlternate = @"<br(|\s\x2F)>";

        public const string Span = "<span.*>.*?(<\x2Fspan>)";
        public const string SpanOpeningTag = "<span.*?>";
        public const string SpanClosingTag = "<\x2Fspan>";

        public const string Bold = "<b>.*?(<\x2Fb>)";
        public const string BoldOpeningTag = "<b>";
        public const string BoldClosingTag = "<\x2Fb>";

        // <a>hyperlinktags<\a>
        public const string Hyperlink = "<a.*?(<\x2Fa>)";
        public const string HyperlinkOpeningTag = "<a.*?>";
        public const string HyperlinkClosingTag = "<\x2Fa>";

        // <a>everythingbetweenthehyperlinktags<\a>
        public const string HyperlinkContent = "(?<=<a.*>).*?(?=<\x2Fa>)";

        // <a href="patterntogetthisurl">
        public const string HyperlinkHrefContent = "(?<=<a.*href=\x22).*?(?=\x22)";

        // Google's custom span tag for wrapping a profile link.
        public const string GoogleProfileLinkWrapper = "<span class=\x22proflinkWrapper.*?(<\x2Fa><\x2Fspan>)";
    }
}
