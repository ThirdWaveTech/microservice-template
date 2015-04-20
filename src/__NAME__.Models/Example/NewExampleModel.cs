namespace __NAME__.Models.Example
{
    public class ExampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }

    public class NewExampleModel
    {
        public string Name { get; set; }
    }

    public class NewExampleCreatedModel
    {
        public int Id { get; set; }
    }

    public class CloseExampleModel
    {
        public int Id { get; set; }
    }
}
