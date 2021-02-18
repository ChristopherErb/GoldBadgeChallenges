using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repo
{

    public enum ClaimType { Car = 1, Home, Theft }
    

    
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }

        public string ClaimDesc { get; set; }

        public decimal ClaimAmt { get; set; }

        public DateTime IncidentDate { get; set; }

        public DateTime ClaimDate { get; set; }
        public bool ClaimValid { get; set; }


        public Claim() { }

        public Claim (
            int claimID,
            string claimDesc,
            decimal claimAmt,
            DateTime incidentDate,
            DateTime claimDate,
            bool claimValid,
            ClaimType claimType
            )
        {
            ClaimID = claimID;
            ClaimDesc = claimDesc;
            ClaimAmt = claimAmt;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            ClaimValid = claimValid;
            ClaimType = claimType;

        }

       

    }
}
