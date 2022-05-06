using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Newtonsoft.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;

namespace FunctionAppTest.Entities
{
    [OpenApiExample(typeof(BookRequestExample))]
    public class BookRequest
    {
        /// <summary>The name of the book</summary>
        [OpenApiProperty]
        public string Name { get; set; }

        /// <summary>The description of the book</summary>
        [OpenApiProperty]
        public string Description { get; set; }
    }

    public class BookRequestExample : OpenApiExample<BookRequest>
    {
        public override IOpenApiExample<BookRequest> Build(NamingStrategy namingStrategy = null)
        {

           this.Examples.Add(
                OpenApiExampleResolver.Resolve(
                    "BookRequestExample",
                    new BookRequest()
                    {
                       Name = "Sample Book",
                       Description = "This is a great book on learning Azure Functions"
                    },
                    namingStrategy
                ));

            return this;
        }
    }
}
