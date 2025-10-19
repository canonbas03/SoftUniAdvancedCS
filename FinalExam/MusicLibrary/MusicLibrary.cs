using System.Text;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public string Name { get; }
        public int Capacity { get; }
        public List<Track> Tracks { get; }

        public MusicLibrary(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            if (Tracks.Count < Capacity)
            {
                if (!Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist))
                {
                    Tracks.Add(track);
                }
            }
        }

        public bool RemoveTrack(string title, string artist)
        {
            Track trackToRemove = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);

            return Tracks.Remove(trackToRemove);
        }

        public Track GetLongestTrack()
        {
            int maxDuration = Tracks.Max(t => t.Duration);
            Track track = Tracks.FirstOrDefault(t => t.Duration == maxDuration);
            return track;
        }

        public string GetTrackDetails(string title, string artist)
        {
            Track track = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);

            if (track != default)
            {
                return track.ToString();
            }
            return "Track not found!";
        }

        public int GetTracksCount()
        {
            return Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            List<Track> tracksOrdered = new List<Track>();
            tracksOrdered = Tracks.Where(t => t.Genre == genre).OrderBy(t => t.Duration).ToList();
            return tracksOrdered;
        }

        public string LibraryReport()
        {
            List<Track> orderedTracks = new List<Track>();
            orderedTracks = Tracks.OrderByDescending(t => t.Duration).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Music Library: {Name}");
            sb.AppendLine($"Tracks capacity: {Capacity}");
            sb.AppendLine($"Number of tracks added: {Tracks.Count}");
            sb.AppendLine("Tracks:");
            foreach (Track track in orderedTracks)
            {
                sb.AppendLine($"-{track}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
