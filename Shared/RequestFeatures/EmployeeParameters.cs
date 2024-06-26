﻿namespace Shared.RequestFeatures
{
    public class CompanyParameters : RequestParameters
    {
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;
        public bool ValidAgeRange => MaxAge > MinAge;
        public string? SearchTerm { get; set; }
        public CompanyParameters() => OrderBy = "name";

    }
}
