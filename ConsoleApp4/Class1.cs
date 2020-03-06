
public class GetQuestion
{
    public int id { get; set; }
    public string question_text { get; set; }
    public Test_Input test_input { get; set; }
    public Sample_Input sample_input { get; set; }
    public Sample_Output sample_output { get; set; }
}

public class Test_Input
{
    public string text { get; set; }
}

public class Sample_Input
{
    public string text { get; set; }
}

public class Sample_Output
{
    public int a { get; set; }
    public int e { get; set; }
    public int i { get; set; }
    public int o { get; set; }
    public int u { get; set; }
}

