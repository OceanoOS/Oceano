using System;
using System.Collections.Generic;

namespace Oceano.Utilities
{
    public static class HTMLParser
    {
        public static void ParseHtml(string html)
        {
            Stack<string> tagStack = new();

            int pos = 0;
            while (pos < html.Length)
            {
                int startTag = html.IndexOf('<', pos);
                if (startTag == -1)
                {
                    break;
                }
                int endTag = html.IndexOf('>', startTag);
                if (endTag == -1)
                {
                    break;
                }

                string tag = html.Substring(startTag, endTag - startTag + 1);
                string tagName = tag[1..^1];
                string[] attributes = tagName.Split(' ');

                if (!tag.StartsWith("</") && !tag.EndsWith("/>"))
                {
                    Console.WriteLine($"Tag: {attributes[0]}");

                    if (attributes.Length > 1)
                    {
                        for (int i = 1; i < attributes.Length; i++)
                        {
                            string[] attr = attributes[i].Split('=');
                            string attrName = attr[0];
                            string attrValue = attr[1].Trim('\"');
                            Console.WriteLine($"Attribute {i}: {attrName} = {attrValue}");
                        }
                    }

                    tagStack.Push(attributes[0]);
                }
                else if (tag.EndsWith("/>"))
                {
                    string selfClosingTagName = tag[1..^2];

                    Console.WriteLine($"Self-closing Tag: {selfClosingTagName}");

                    if (attributes.Length > 1)
                    {
                        for (int i = 1; i < attributes.Length; i++)
                        {
                            string[] attr = attributes[i].Split('=');
                            string attrName = attr[0];
                            string attrValue = attr[1].Trim('\"');
                            Console.WriteLine($"Attribute {i}: {attrName} = {attrValue}");
                        }
                    }
                }
                else
                {
                    string closingTag = attributes[0][1..];
                    if (tagStack.Count > 0 && tagStack.Peek() == closingTag)
                    {
                        _ = tagStack.Pop();

                        Console.WriteLine($"Closing Tag: {closingTag}");
                    }
                    else
                    {
                        break;
                    }
                }

                pos = endTag + 1;
            }
            while (tagStack.Count > 0)
            {
                Console.WriteLine($"Unmatched Opening Tag: {tagStack.Pop()}");
            }
        }
    }
}