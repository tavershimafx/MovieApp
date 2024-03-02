namespace MusicApp.Models
{
    public class MovieSearch
    {
        public long Id { get; set; }
        public string Query { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }

    public class MovieSnapshot
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class MovieDetail
    {
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public IEnumerable<RatingSource> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
    }

    public class RatingSource
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class MovieSearchResponse
    {
        public IEnumerable<MovieSnapshot> Search { get; set; }
        public int TotalResults { get; set; }
        public bool Response { get; set; }
    }
}