namespace CheckpointBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }

    }
}
