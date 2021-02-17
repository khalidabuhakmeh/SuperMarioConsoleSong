using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Super Mario Bros
// (Ported from http://www.portal42.net/mario.txt)
var music = new List<Sound> {
    new Tone(659), new Tone(659), new Silence(), new Tone(659), new Silence(167), new Tone(523),
    new Tone(659), new Silence(), new Tone(784), new Silence(375), new Tone(392), new Silence(375),
    new Tone(523), new Silence(250), new Tone(392), new Silence(250), new Tone(330), new Silence(250),
    new Tone(440), new Silence(), new Tone(494), new Silence(), new Tone(466), new Silence(42),
    new Tone(440), new Silence(), new Tone(392), new Silence(), new Tone(659), new Silence(),
    new Tone(784), new Silence(), new Tone(880), new Silence(), new Tone(698), new Tone(784),
    new Silence(), new Tone(659), new Silence(), new Tone(523), new Silence(), new Tone(587),
    new Tone(494), new Silence(), new Tone(523), new Silence(250), new Tone(392), new Silence(250),
    new Tone(330), new Silence(250), new Tone(440), new Silence(), new Tone(494), new Silence(),
    new Tone(466), new Silence(42), new Tone(440), new Silence(), new Tone(392), new Silence(),
    new Tone(659), new Silence(), new Tone(784), new Silence(), new Tone(880), new Silence(),
    new Tone(698), new Tone(784), new Silence(), new Tone(659), new Silence(), new Tone(523),
    new Silence(), new Tone(587), new Tone(494), new Silence(375), new Tone(784), new Tone(740),
    new Tone(698), new Silence(42), new Tone(622), new Silence(), new Tone(659), new Silence(167),
    new Tone(415), new Tone(440), new Tone(523), new Silence(), new Tone(440),
    new Tone(523), new Tone(587), new Silence(250), new Tone(784), new Tone(740), new Tone(698), new Silence(42),
    new Tone(622), new Silence(), new Tone(659), new Silence(167), new Tone(698), new Silence(),
    new Tone(698), new Tone(698), new Silence(625), new Tone(784), new Tone(740),
    new Tone(698), new Silence(42), new Tone(622), new Silence(), new Tone(659), new Silence(167), new Tone(415),
    new Tone(440), new Tone(523), new Silence(), new Tone(440), new Tone(523),
    new Tone(587), new Silence(250), new Tone(622), new Silence(250), new Tone(587), new Silence(250), new Tone(523),
    new Silence(1125), new Tone(784), new Tone(740), new Tone(698), new Silence(42), new Tone(622),
    new Silence(), new Tone(659), new Silence(167), new Tone(415), new Tone(440), new Tone(523),
    new Silence(), new Tone(440), new Tone(523), new Tone(587), new Silence(250), new Tone(784),
    new Tone(740), new Tone(698), new Silence(42), new Tone(622), new Silence(), new Tone(659),
    new Silence(167), new Tone(698), new Silence(), new Tone(698), new Tone(698), new Silence(625),
    new Tone(784), new Tone(740), new Tone(698), new Silence(42), new Tone(622), new Silence(),
    new Tone(659), new Silence(167), new Tone(415), new Tone(440), new Tone(523),
    new Silence(), new Tone(440), new Tone(523), new Tone(587), new Silence(250),
    new Tone(622), new Silence(250), new Tone(587), new Silence(250), new Tone(523),
    new Silence(625),
};

var info = new ProcessStartInfo("play", "-n " + string.Join(" : ", music.Select(x => x.ToString())));
var result = Process.Start(info);
result?.WaitForExit(music.Sum(x => x.Duration) + 500);

Console.Write(
    @"

____▒▒▒▒▒
—-▒▒▒▒▒▒▒▒▒
—–▓▓▓░░▓░
—▓░▓░░░▓░░░
—▓░▓▓░░░▓░░░
—▓▓░░░░▓▓▓▓
——░░░░░░░░
—-▓▓▒▓▓▓▒▓▓
–▓▓▓▒▓▓▓▒▓▓▓
▓▓▓▓▒▒▒▒▒▓▓▓▓
░░▓▒░▒▒▒░▒▓░░
░░░▒▒▒▒▒▒▒░░░
░░▒▒▒▒▒▒▒▒▒░░
—-▒▒▒ ——▒▒▒
–▓▓▓———-▓▓▓
▓▓▓▓———-▓▓▓▓

");


// data structures for sounds
public abstract record Sound(int Duration = 125)
{
    protected double Length => TimeSpan.FromMilliseconds(Duration).TotalSeconds;
}

public record Silence(int Duration = 125) : Sound(Duration)
{
    public override string ToString() => $"synth {Length} sine 0";
}

public record Tone(int Frequency, int Duration = 125) : Sound(Duration)
{
    public override string ToString() => $"synth {Length} sine {Frequency}";
}