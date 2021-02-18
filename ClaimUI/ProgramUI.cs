using KomodoClaims;
using KomodoClaims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimUI
{
    class ProgramUI
    {

        private readonly Claim_Repo _repo = new Claim_Repo();


        public void Run()
        {
            Menu();
        }


        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to Komodo Insurance Claim System \n" +
                    "Please select the option that best suits your needs \n" + 
                    "0. Exit \n" +
                    "1. See all claims \n" +
                    "2. Work current claim \n" +
                    "3. Enter a new claim \n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        continueToRun = false;
                        break;
                    case "1":
                        ShowAllContent();
                        break;
                    case "2":
                        HandleclaimNow();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                }
            }
        }

        private readonly List<Claim> _directory = new List<Claim>();

        string str1 = "ClaimID";
        string str2 = "Type";
        string str3 = "Description";
        string str4 = "Amount";
        string str5 = "DateOfAccident";
        string str6 = "DateOfClaim";
        string str7 = "IsValid";

        private void DisplayAllContent(Claim content)
        { 
            
         


           Console.WriteLine($"__{content.ClaimID}_____{content.ClaimType}_____{content.ClaimDesc}______{content.ClaimAmt}____" +
               $"___{content.IncidentDate.ToString("dd/mm/yyyy")}______{content.ClaimDate.ToString("dd/mm/yyyy")}________{content.ClaimValid}");

        }

        //I'm stuck here.  I've been stuck here for almost an entire day. I cant figure out WHY this is not working. 
        //Moving on to other parts of the challenge to try to accumulate some points and at leat make it passed gold.
        //Case 1
        private void ShowAllContent()
        {
            Console.Clear();
            List<Claim> listOfContent = _repo.GetContents(); 
            Console.WriteLine(str1.PadRight(10) +
                       str2.PadRight(10) +
                       str3.PadRight(15) +
                       str4.PadRight(10) +
                       str5.PadRight(18) +
                       str6.PadRight(18) +
                       str7.PadRight(10));

            foreach (Claim content in listOfContent)
            {
                DisplayAllContent(content);
            }
            Console.ReadKey();
        }

                
        //Case 2
        public void HandleclaimNow()
        {
            bool continueToRun = true;
            Claim content2 = new Claim();
            while (continueToRun)

            {
                Console.WriteLine("Would you like to handle the claim now(y/n)?");
                string handleInput = Console.ReadLine();
                switch (handleInput)
                {
                    case "y":
                        Console.Clear();
                        List<Claim> listOfContent = _repo.GetContents();
                        Console.WriteLine(str1.PadRight(10) +
                                   str2.PadRight(10) +
                                   str3.PadRight(15) +
                                   str4.PadRight(10) +
                                   str5.PadRight(18) +
                                   str6.PadRight(18) +
                                   str7.PadRight(10));

                        foreach (Claim content in listOfContent)
                        {
                            DisplayAllContent(content);
                        }
                        Console.ReadKey();
                        break;
                    case "n":
                        continueToRun = false;
                        break;
                }
            }
        }

        //Case 3
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim Content = new Claim();
            Console.WriteLine("Enter the claim ID");
            Content.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select the claim type \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimTypeString = Console.ReadLine();
            int claimTypeID = int.Parse(claimTypeString);
            Content.ClaimType = (ClaimType)claimTypeID;
            Console.WriteLine("Please enter a claim description");
            Content.ClaimDesc = Console.ReadLine();
            Console.WriteLine("Please enter the amount of damages");
            Content.ClaimAmt = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter the date of the accident");
            Content.IncidentDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the date of the claim");
            Content.ClaimDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please decide if this is a valid claim(True/False)");
            Content.ClaimValid = Convert.ToBoolean(Console.ReadLine());
            _repo.AddContentToDirectory(Content);
        }


       



    }
}
