using AutoFixture;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Moravia.Homework.Domain.Deserializer;
using Moravia.Homework.Domain.Types;

using Xunit;

namespace Moravia.Homework.Tests.Domain.Deserializer;
public class XmlFormatDeserializerTests
{
    private readonly XmlFormatDeserializer xmlDeserializer;
    private readonly ILogger<XmlFormatDeserializer> logger = Mock.Of<ILogger<XmlFormatDeserializer>>();
    private readonly Fixture fixture = new();

    public XmlFormatDeserializerTests()
    {
        xmlDeserializer = new(logger);
    }

    [Fact]
    public void Deserialize_OK()
    {
        var title = fixture.Create<string>();
        var text = fixture.Create<string>();

        var input = @$"
<?xml version=""1.0"" encoding=""utf-16""?>
<Document xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Title>{title}</Title>
  <Text>{text}</Text>
</Document>";

        var expected = new Document { Title = title, Text = text };

        var actual = xmlDeserializer.Deserialize<Document>(input);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Deserialize_EmptyInput_ShouldReturnNull()
    {
        var input = string.Empty;

        var actual = xmlDeserializer.Deserialize<Document>(input);

        actual.Should().BeNull();
    }

    [Fact]
    public void Deserialize_InvalidXml_ShouldReturnNull()
    {
        var input = "invalid xml right here";

        var actual = xmlDeserializer.Deserialize<Document>(input);

        actual.Should().BeNull();
    }
}
