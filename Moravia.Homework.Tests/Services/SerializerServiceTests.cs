using AutoFixture;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Domain.Types;
using Moravia.Homework.Services;

using Xunit;

namespace Moravia.Homework.Tests.Services;
public class SerializerServiceTests
{
    private readonly SerializerService serializerService;
    private readonly ILogger<SerializerService> logger = Mock.Of<ILogger<SerializerService>>();
    private readonly Mock<IFileSaverFactory> fileSaverFactoryMock = new();
    private readonly Mock<IFileSaver> fileSaverMock = new();
    private readonly Mock<ISerializerFactory> serializerFactoryMock = new();
    private readonly Mock<ISerializer> serializerMock = new();

    private readonly Fixture fixture = new();

    public SerializerServiceTests()
    {
        serializerService = new(logger, serializerFactoryMock.Object, fileSaverFactoryMock.Object);
    }

    [Fact]
    public void Serialize_OK()
    {
        var data = fixture.Create<Document>();
        var context = fixture.Create<SerializationContext>();

        var serializedData = fixture.Create<string>();

        fileSaverFactoryMock.Setup(x => x.Create(It.IsAny<LocationType>())).Returns(fileSaverMock.Object);
        serializerFactoryMock.Setup(x => x.Create(It.IsAny<FileFormat>())).Returns(serializerMock.Object);
        serializerMock.Setup(x => x.Serialize(It.IsAny<Document>())).Returns(serializedData);

        var succ = serializerService.Serialize(data, context);

        succ.Should().BeTrue();
        serializerFactoryMock.Verify(x => x.Create(context.Format), Times.Once);
        serializerMock.Verify(x => x.Serialize(data), Times.Once);
        fileSaverFactoryMock.Verify(x => x.Create(context.Location), Times.Once);
        fileSaverMock.Verify(x => x.SaveFileFromString(context.FileName, serializedData), Times.Once);
    }

    [Fact]
    public void Serialize_FailedSave_ShouldReturnFalse()
    {
        var data = fixture.Create<Document>();
        var context = fixture.Create<SerializationContext>();

        fileSaverFactoryMock.Setup(x => x.Create(It.IsAny<LocationType>())).Returns(fileSaverMock.Object);
        fileSaverMock.Setup(x => x.SaveFileFromString(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var actual = serializerService.Serialize(data, context);
        
        actual.Should().BeFalse();
    }

    [Fact]
    public void Serialize_NoData_ShouldReturnFalse()
    {
        var data = null as Document;
        var context = fixture.Create<SerializationContext>();

        var succ = serializerService.Serialize(data, context);

        succ.Should().BeFalse();
    }

    [Fact]
    public void Serialize_NoContext_ShouldThrowArgumentNullException()
    {
        var data = fixture.Create<Document>();
        var context = null as SerializationContext;

#pragma warning disable CS8604 // intentional null reference argument 
        var action = () => serializerService.Serialize(data, context);
#pragma warning restore CS8604 

        action.Should().Throw<ArgumentNullException>();
    }
}
