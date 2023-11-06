namespace CheckpointBlog.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? NomeAutor { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataComentario{ get; set; }
        public int PostId{ get; set; }
        public Post Post{ get; set; }
    }
}
