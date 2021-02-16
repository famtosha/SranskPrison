public class Dialog
{
    public DialogData data { get; }
    private int position = 0;

    public Dialog(DialogData data)
    {
        this.data = data;
    }

    public bool CanRead()
    {
        return position < data.text.Length;
    }

    public char GetNextChar()
    {
        var temp = data.text[position];
        position++;
        return temp;
    }
}
