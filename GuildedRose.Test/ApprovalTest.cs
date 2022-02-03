using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using csharp;


namespace GuildedRose.Test
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {

        [Test]
        public void ThirtyDays()
        {

            StringBuilder fakeoutput = new StringBuilder();

            // Redirect standard output from the console to the stringwritter qui ecrit dans fakeoutput 
            Console.SetOut(new StringWriter(fakeoutput));
            // Redirect  input to the console
            Console.SetIn(new StringReader("a\n"));


            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }


    }
}
