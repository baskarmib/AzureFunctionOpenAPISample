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

    [OpenApiExample(typeof(BookResponseExample))]
    public class BookResponse
    {
        /// <summary>
        /// The name of the book
        /// </summary>
        [OpenApiProperty]
        public string Name { get; set; }
        /// <summary>
        /// The Id of the Book in Guid Format
        /// </summary>
        [OpenApiProperty]
        public Guid BookId { get; set; }

        /// <summary>
        /// The description of the book
        /// </summary>
        [OpenApiProperty]
        public string Description { get; set; }
    }

    public class BookResponseExample : OpenApiExample<BookResponse>
    {
        public override IOpenApiExample<BookResponse> Build(NamingStrategy namingStrategy = null)
        {

            this.Examples.Add(
                 OpenApiExampleResolver.Resolve(
                     "BookResponseExample",
                     new BookResponse()
                     {
                         Name = "Sample Book",
                         Description = "This is a great book on learning Azure Functions",
                         BookId = new Guid()

                     },
                     namingStrategy
                 ));

            return this;
        }
    }
}
