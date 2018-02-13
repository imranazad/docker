using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nest;

namespace Docker.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        private ElasticClient Client;

        [OneTimeSetUp]
        public void Setup()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("nice");
            Client = new ElasticClient(settings);
            Client.DeleteIndex("nice");
            Client.IndexDocument(new Document() { Introduction = "hello my name is imran" });
            Thread.Sleep(5000);
        }

        [Test]
        public void ShouldQueryElasticAndUppercase()
        {
            var searchResponse = Client.Search<Document>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Introduction)
                        .Query("Imran")
                    )
                )
            );

            var result = Uppercaser.Uppercase(searchResponse.Documents.First().Introduction);

            Assert.AreEqual("HELLO MY NAME IS IMRAN", result);
        }
    }
}
