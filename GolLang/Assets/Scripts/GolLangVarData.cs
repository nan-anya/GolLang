public class GolLangVarData
{
    public string name;

    public int value;

    public ValueType type;

    public GolLangVarData(string name, int value, ValueType type)
    {
        this.name = name;
        this.value = value;
        this.type = type;
    }

    public override string ToString()
    {
        return type.ToString() + " : " + name + " : " + value.ToString();
    }
}
