using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorAdvice
{
    private Dictionary<Color, List<Color>> colorToAdvice;

    public ColorAdvice()
    {
        colorToAdvice = new Dictionary<Color, List<Color>>
        {
            {
                new Color(0.78f, 0.87f, 0.94f), // pastel blue
                new List<Color> { // White, Lavender, Beige, Soft Yellow
                new Color(0.86f, 0.80f, 0.94f),
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.98f, 0.93f, 0.80f),
        }
            },
            {
                new Color(0.97f, 0.85f, 0.77f), // Pastel Peach 
                new List<Color> {
                new Color(0.79f, 0.89f, 0.87f), // mint
                new Color(0.98f, 0.93f, 0.80f), // yellow
                new Color(0.78f, 0.87f, 0.94f), // lavender
        }
            },
            {
                new Color(0.98f, 0.93f, 0.80f),// pastel Yellow 
                new List<Color> {
                new Color(1.00f, 1.00f, 1.00f), // white
                new Color(0.78f, 0.87f, 0.94f), // blue
                new Color(0.79f, 0.89f, 0.87f), // green
        }
            },
            {
                new Color(0.79f, 0.89f, 0.87f), // pastel green
                new List<Color> { // White, Peach, Lilac
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.97f, 0.85f, 0.77f),
                new Color(0.86f, 0.80f, 0.94f),
        }
            },
            {
                new Color(0.95f, 0.78f, 0.87f), // pastel rose
                new List<Color> { // White, Mint Green, Peach
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.79f, 0.89f, 0.87f),
                new Color(0.97f, 0.85f, 0.77f),
        }
            },
            {
                new Color(0.86f, 0.80f, 0.94f), // pastel Lavender
                new List<Color> { //White, Mint, Pastel Yellow
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.79f, 0.89f, 0.87f),
               new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.98f, 0.78f, 0.79f), // pastel red
                new List<Color> { // White,Soft Yellow, 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.20f, 0.55f, 0.95f), // blue
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.60f, 0.30f, 0.95f), // purple
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.95f, 0.20f, 0.55f), // pink
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.95f, 0.25f, 0.25f), // red
                new List<Color> { // 
                new Color(0.00f, 0.00f, 0.00f),
                new Color(1.00f, 1.00f, 1.00f),
                new Color(1.00f, 0.90f, 0.00f),
        }
            },
            {
                new Color(0.98f, 0.55f, 0.15f), // orange
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(1.00f, 0.90f, 0.00f),// yellow
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            },
            {
                new Color(0.00f, 0.80f, 0.70f),// green
                new List<Color> { // 
                new Color(1.00f, 1.00f, 1.00f),
                new Color(0.78f, 0.87f, 0.94f),
        }
            }
        };

    }


    public List<Color> GetAdvice(Color color)
    {
        if (colorToAdvice.TryGetValue(color, out var advice))
            return advice;
        return new List<Color>();
    }
}