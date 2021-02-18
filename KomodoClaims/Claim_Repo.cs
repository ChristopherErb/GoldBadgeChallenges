using KomodoClaims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{


    public class Claim_Repo
    {



        private readonly List<Claim> _directory = new List<Claim>();

        public int count
        {
            get
            {
                return _directory.Count;
            }
        }
        public bool AddContentToDirectory(Claim Content)
        {
            int startingCount = _directory.Count;
            _directory.Add(Content);
            bool wasAdded = _directory.Count > startingCount;
            return wasAdded;
        }


        public List<Claim> GetContents()
        {
        return _directory;
        }


        public Claim GetClaim(int ClaimID)
        {
            foreach (Claim content in _directory)
            {
                if (ClaimID == content.ClaimID)
                {
                    return content;
                }
            }
            return null;
        } 



        public bool ClaimAvailable(Claim content)
        {
            if (content.ClaimID >= 1)
            {
                return true;
            }
            else
                return false;

        }

    
/*
 * 
 * 
 * 
 * 
 * 
        Methods that
            see claims





            take care of next claim






            enter new claim*/



    }
}
