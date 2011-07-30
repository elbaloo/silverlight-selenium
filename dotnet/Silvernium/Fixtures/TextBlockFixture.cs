﻿namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class TextBlockFixture : ComponentFixture
    {
        public TextBlockFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public TextBlockFixture RequireText(string text)
        {
            var actualText = Call("GetValue", Path);
            if (text != actualText)
            {
                throw new SilverniumFixtureException("Text block doesn't contains expected text '"
                    + text + "' (actual: '" + actualText + "')");
            }
            return this;
        }

        public TextBlockFixture RequireContains(string partialText)
        {
            var fullText = Call("GetValue", Path);
            if (fullText == null || !fullText.Contains(partialText))
            {
                throw new SilverniumFixtureException("Text block does not contains expected partial text " + partialText
                    + " (actual: " + fullText + ")");
            }
            return this;
        }

        public TextBlockFixture RequireNotContains(string partialText)
        {
            var fullText = Call("GetValue", Path);
            if (fullText != null && fullText.Contains(partialText))
            {
                throw new SilverniumFixtureException("Text block contains unexpected partial text " + partialText
                    + " (actual: " + fullText + ")");
            }
            return this;
        }
    }
}