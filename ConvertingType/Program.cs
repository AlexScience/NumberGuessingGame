
int a = 0;
int b = 1;
int result = (a + b) / 2;

float num1 = 0;
float num2 = 1;
float result2 = (num1 + num2) / 2;
int convert = (int)Math.Round(result2, MidpointRounding.AwayFromZero);


Console.WriteLine(result);
Console.WriteLine(result2);
Console.WriteLine($"Convert-{convert}");

