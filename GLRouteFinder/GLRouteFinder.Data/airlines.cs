namespace GLRouteFinder
{
    public class airlines
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TwoDigitCode {get;set;}
        public string ThreeDigitCode { get; set; }
        public string Country { get; set; }
    }
    public class airports {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA3 { get; set; }
        public string Latitute { get; set; }
        public string Longitude { get; set; }

    }
    public class airportsVM
    {
        public string IATA3 { get; set; }
        public string Latitute { get; set; }
        public string Longitude { get; set; }

    }
    public class routesVM
    {
        public string Origin { get; set; }
        public string Destination { get; set; }

    }
    public class routes
    {
        public int ID { get; set; }
        public string AirlineId { get; set; }
        public string Origin {get;set;}
        public string Destination { get; set; }

    }
}