var fs = 16000.0;
var f = 1000.0;
var d = 1.0 / fs;
var w = 2 * fs * Math.Tan(Math.PI * f / fs);

var b0 = d * d * w;
var b1 = 2 * d * d * w;
var b2 = d * d * w;

var a0 = d * d * w * w + 4;
var a1 = 2 * d * d * w * w - 8;
var a2 = d * d * w * w + 4;

b0 /= a0;
b1 /= a0;
a1 /= a0;
a2 /= a0;

var y = new double[100];
var x = new double[100];
x[0] = 1;

for (var t = 2; t < y.Length; t++)
{
    y[t] = b0 * x[t] + b1 * x[t - 1] + b2 * x[t - 2] - a1 * y[t - 1] - a2 * y[t - 2];
}

File.WriteAllLines("out.csv", y.Select(value => value.ToString()));
