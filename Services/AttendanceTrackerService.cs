namespace event_ease.Services
{
    public class AttendanceTrackerService
    {
        private readonly List<Attendance> _attendanceRecords = new()
        {
            new Attendance { EventId = 1, UserName = "John Doe", Email = "j.doe@hotmail.com"},
            new Attendance { EventId = 1, UserName = "James Cook", Email = "j.cook@hotmail.com"},
            new Attendance { EventId = 1, UserName = "Sheldon Cooper", Email = "s.cooper@hotmail.com"}
        };
        private int _nextEventId = 1; // Counter for auto-incrementing EventId

        public int CreateNewEvent()
        {
            int newEventId = _nextEventId;
            _nextEventId++; // Increment the counter for the next event
            return newEventId;
        }

        public void RegisterAttendance(int eventId, string userName, string email)
        {
            if (!_attendanceRecords.Any(a => a.EventId == eventId && a.Email == email))
            {
                _attendanceRecords.Add(new Attendance
                {
                    EventId = eventId,
                    UserName = userName,
                    Email = email
                });
            }
        }

        public List<Attendance> GetAttendeesForEvent(int eventId)
        {
            return _attendanceRecords.Where(a => a.EventId == eventId).ToList();
        }

        public List<Attendance> GetAllAttendees()
        {
            return _attendanceRecords;
        }
    }
}