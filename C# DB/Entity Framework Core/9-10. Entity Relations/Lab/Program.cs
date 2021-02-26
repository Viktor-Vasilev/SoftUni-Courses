using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Install Nudget Packages:
            // 1. Microsoft.EntityFrameworkCore.SqlServer
            // 2. Microsoft.EntityFrameworkCore.Design

            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models - f - d


            // -o   задава папка в която да постави класовете
            // -f   ако вече имаме направена база във вид на класове и сме променили нещо в базата през SQL, с тази команда му казваме да дръпне пак всичко наново като презапише класовете.
            // -d    тази команда ни прави констрейните на базата като атрибути върху самите пропъртитата






        }
    }
}
