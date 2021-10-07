﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class Claims
    {
        public int ClaimID { get; set; }

        public ClaimType ClaimType { get; set; }

        public string Description { get; set; }

        public double ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public int TotalDays
        {
            get
            {
                TimeSpan claimSubmitDiff = DateOfClaim - DateOfIncident;
                double convertedDays = Math.Floor(claimSubmitDiff.TotalDays);
                int dayTotal = Convert.ToInt32(convertedDays);
                return dayTotal;
            }
        }

        public bool IsValid
        {
            get
            {
                if (TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        public Claims() { }

        public Claims(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }

    }

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
}
