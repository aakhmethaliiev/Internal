namespace MessengerModel.Model
{
    public class Model : IModel
    {
        public Model()
        {
            Text = "Hello";
        }

        public string Text { get; set; }
    }
}
