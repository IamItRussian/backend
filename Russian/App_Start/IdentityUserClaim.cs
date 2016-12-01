using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Russian.App_Start
{
    public class IdentityUserClaim
    {

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public IdentityUserClaim()
        {

        }

        public IdentityUserClaim(Claim claim)
        {
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }

        

    }
}