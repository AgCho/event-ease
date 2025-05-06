namespace event_ease.Services
{
    public class EventService
    {
        private readonly List<Event> _events = new(){
            new Event { Name = "Tech Conference 2025", Date = new DateTime(2025, 5, 15), Location = "San Francisco, CA", Email = "techconf2025@example.com", IsCompleted = false },
            new Event { Name = "Music Festival", Date = new DateTime(2025, 6, 20), Location = "Austin, TX", Email = "musicfest@example.com", IsCompleted = false },
            new Event { Name = "Art Expo", Date = new DateTime(2025, 7, 10), Location = "New York, NY", Email = "artexpo@example.com", IsCompleted = false }
        };

        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }

        public void DeleteEvent(string eventName)
        {
            var eventToDelete = _events.FirstOrDefault(e => e.Name == eventName);
            if (eventToDelete != null)
            {
                _events.Remove(eventToDelete);
            }
        }

        public void CompleteEvent(string eventName)
        {
            var eventToComplete = _events.FirstOrDefault(e => e.Name == eventName);
            if (eventToComplete != null)
            {
                eventToComplete.IsCompleted = true; // Mark the event as completed
            }
        }
    }
}