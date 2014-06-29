using System;
using System.Collections.Generic;
using Moq;
using OefeningenLogo;
using OefeningenLogo.Backend;
using Xunit;

namespace OefeningenLogoTest
{
    public class Given_an_OefeningenGenerator
    {
        public const string Line1 = "test1";
        public const string Line2 = "test2";
        private readonly Mock<IGeneratePdfs> _pdfGeneratorMock;
        private readonly DateTime _datum;

        public Given_an_OefeningenGenerator()
        {
            _pdfGeneratorMock = new Mock<IGeneratePdfs>();

            var sut = new OefeningenGenerator(_pdfGeneratorMock.Object);

            _datum = new DateTime(2014, 5, 2);
            var oefeningenDefinitieSetMock = new Mock<IOefeningenDefinitieSet>();
            oefeningenDefinitieSetMock
                .Setup(od => od.GetOefeningen(It.IsAny<int>()))
                .Returns(new List<string> { Line1, Line2 });

            sut.MaakOefeningenLogo(_datum, _datum, oefeningenDefinitieSetMock.Object);
        }

        public Mock<IGeneratePdfs> PdfGeneratorMock
        {
            get { return _pdfGeneratorMock; }
        }

        public DateTime Datum
        {
            get { return _datum; }
        }
    }

    public class When_I_ask_to_generate_a_sheet_of_oefeningen : IUseFixture<Given_an_OefeningenGenerator>
    {
        private Given_an_OefeningenGenerator _fixture;

        public void SetFixture(Given_an_OefeningenGenerator fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void It_Initializes_the_page()
        {
            _fixture.PdfGeneratorMock.Verify(pg => pg.InitializePage(_fixture.Datum), Times.Once);
        }

        [Fact]
        public void It_adds_line1()
        {
            _fixture.PdfGeneratorMock.Verify(pg => pg.AddLine(Given_an_OefeningenGenerator.Line1), Times.Once);
        }

        [Fact]
        public void It_adds_line2()
        {
            _fixture.PdfGeneratorMock.Verify(pg => pg.AddLine(Given_an_OefeningenGenerator.Line2), Times.Once);
        }

        [Fact]
        public void It_Writes_the_pdf()
        {
            _fixture.PdfGeneratorMock.Verify(pg => pg.Write(), Times.Once);
        }
    }
}
