using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepository
    {
        public Queue<Claim> _claimRepository = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            return _claimRepository;
        }
        public void SeeAllClaims()
        {
            Console.WriteLine($"{"ID", -5} {"Type", -5} {"Description", -20} {"Amount", -10} {"DateOfIncident", -15} {"DateOfClaim", -15} {"IsValid", -10}\n");
            foreach (Claim claim in _claimRepository)
            {
                Console.WriteLine($"{claim.ClaimID, -5} {claim.ClaimType, -5} {claim.Description, -20} ${claim.ClaimAmount, -9} {claim.DateOfIncident, -15:MM/dd/yyyy} {claim.DateOfClaim, -15:MM/dd/yyyy} {claim.IsValid, -10}");
            }
        }
        public Claim GetNextClaim()
        {
            Claim nextClaim = _claimRepository.Peek();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine("ClaimID: " + nextClaim.ClaimID);
            Console.WriteLine("Type: " + nextClaim.ClaimType);
            Console.WriteLine("Description: " + nextClaim.Description);
            Console.WriteLine("Amount: $" + nextClaim.ClaimAmount);
            Console.WriteLine("Date of Incident: " + nextClaim.DateOfIncident);
            Console.WriteLine("Date of Claim: " + nextClaim.DateOfClaim);
            Console.WriteLine("IsValid: " + nextClaim.IsValid);
            return nextClaim;
        }
        public void DequeueClaim()
        {
            _claimRepository.Dequeue();
        }
        public void AddClaim(Claim newClaim)
        {
            _claimRepository.Enqueue(newClaim);
        }
    }
}
