using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderManager.Classes;

namespace OrderManager
{
    internal class Program
    {
        // Replace with your filepath
        private static readonly string _jsonFilePath = @"C:\Users\km_95\Documents\Projects\Assessment\OrderManager\coding-assigment-orders.json";

        static void Main(string[] args)
        {
            // User Story #1: Create flight schedule based on the Scenario
            Console.WriteLine("Flight Schedule:");
            var flightSchedule = GetFlightSchedule();
            DisplayFlightSchedule(flightSchedule);
            Console.WriteLine("-------------------------");

            // User Story #2: Generate an itinerary by scheduling a batch of orders
            Console.WriteLine("Order Schedule:");
            ScheduleOrders(flightSchedule);
            Console.WriteLine("-------------------------");
        }

        private static List<Flight> GetFlightSchedule()
        {
            List<Flight> flightSchedule = new List<Flight>();
            flightSchedule.Add(new Flight() { FlightNumber = 1, Departure = Location.YUL, Arrival = Location.YYZ, Day = 1, Capacity = 20 });
            flightSchedule.Add(new Flight() { FlightNumber = 2, Departure = Location.YUL, Arrival = Location.YYC, Day = 1, Capacity = 20 });
            flightSchedule.Add(new Flight() { FlightNumber = 3, Departure = Location.YUL, Arrival = Location.YVR, Day = 1, Capacity = 20 });
            flightSchedule.Add(new Flight() { FlightNumber = 4, Departure = Location.YUL, Arrival = Location.YYZ, Day = 2, Capacity = 20 });
            flightSchedule.Add(new Flight() { FlightNumber = 5, Departure = Location.YUL, Arrival = Location.YYC, Day = 2, Capacity = 20 });
            flightSchedule.Add(new Flight() { FlightNumber = 6, Departure = Location.YUL, Arrival = Location.YVR, Day = 2, Capacity = 20 });

            return flightSchedule;
        }

        private static void DisplayFlightSchedule(List<Flight> flightSchedule)
        {
            foreach (Flight flight in flightSchedule)
            {
                Console.WriteLine($@"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        private static void ScheduleOrders(List<Flight> flightSchedule)
        {
            var orders = GetOrdersFromJSONFile();
            
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    bool matched = false;

                    foreach (var flight in flightSchedule.Where(flight => flight.Arrival.ToString() == order.Value.Destination && flight.Capacity > 0))
                    {
                        matched = true;
                        --flight.Capacity;
                        Console.WriteLine($@"order: {order.Key}, flightNumber: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                        break;
                    }

                    if (!matched)
                    {
                        Console.WriteLine($@"order: {order.Key}, flightNumber: not scheduled");
                    }
                }
            }
        }

        private static Dictionary<string, Order> GetOrdersFromJSONFile()
        {
            string jsonContents = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(_jsonFilePath))
                {
                    jsonContents = reader.ReadToEnd();
                }

                Dictionary<string, Order> orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonContents);

                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Dictionary<string, Order>();
            }
        }
    }
}
