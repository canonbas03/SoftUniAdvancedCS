namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var editor = new GraphicEditor();
            editor.DrawShape(new Square());
        }
    }
}
