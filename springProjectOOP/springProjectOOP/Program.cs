using System;

namespace springProjectOOP
{
  enum Cards { Шестерка = 6, Семерка, Восьмерка, Девятка, Десятка, Валет, Дама, Король, Туз }
  class MainDeck
  {
    public const int deckSize = 8;
    private Random random = new Random();
    private readonly int[] deffaultDeck = FillDeffaultDeck();
    private int[] deck;
    public int[] Deck { get { return deck; } set { deck = value; } }
    public MainDeck()
    {
      deck = new int[deckSize];
      shuffle();
    }
    public int[] givePart(int option)
    {
      if (option == 0)
      {
        int[] tmp = new int[deckSize];
        Array.Copy(deck, 0, tmp, 0, deckSize / 2);
        return tmp;
      }
      if (option == 1)
      {
        int[] tmp = new int[deckSize];
        Array.Copy(deck, deckSize / 2, tmp, 0, deckSize / 2);
        return tmp;
      }
      throw new Exception("У нас 2 игрока, какие еще опции");
    }
    private void shuffle()
    {
      deffaultDeck.CopyTo(deck , 0);
      
      for (int i = deckSize - 1; i >= 1; i--)
      {
        int j = random.Next(i + 1);
        var temp = deck[j];
        deck[j] = deck[i];
        deck[i] = temp;
      }
    }
    static private int[] FillDeffaultDeck()
    {
      int[] array = new int[deckSize];
      for (int i = 0; i < deckSize; i += 4)
      {
        for (int j = 0; j < 4; j++)
        {
          array[i + j] = 6 + i / 4;
        }
      }
      return array;
    }
  }
  class Player
  {
    private int index;
    private int[] deck;
    public Player(int[] deck, int index)
    {
      this.deck = deck;
      this.index = index;
    }
    public int UpperCard()
    {
      Console.Write("Колода игрока (доказательство работоспособности:\t");
      Program.PrintArray(deck);
      if (deck[0] == 0)
      {
        Console.WriteLine($"Игрок {index} выиграл");
        return 0;
      }
      int res = deck[0];
      deck[0] = 0;
      int[] tmpArr = new int[MainDeck.deckSize];
      deck.CopyTo(tmpArr , 0);

      for (int i = 1; i < MainDeck.deckSize; i++)
      {
        deck[i - 1] = tmpArr[i];
      }
      return res;
    }
    public void AddCard(int card)
    {
      int i = 0;
      while (deck[i] != 0)
      {
        i++;
        if (i == MainDeck.deckSize)
        {
          Console.WriteLine($"Игрок {index} проиграл");
          return;
        }
      }
      deck[i] = card;
    }
  }
  
  class Game
  {
    private int[] buffer;
    private Player player1, player2;
    private bool warInProgress, playerWon;

    public bool PlayerWon { get { return playerWon; } set { playerWon = value; } }
    
    public Game(Player player1, Player player2)
    {
      this.player1 = player1;
      this.player2 = player2;
      buffer = new int[MainDeck.deckSize];
      playerWon = false;
    }

    public void Start()
    {
      int moves = 0;
      while (!playerWon)
      {
        buffer = new int[MainDeck.deckSize];
        if(moves > 2000) break; // у меня ноут умирает помогите
        
        warInProgress = true;
        while (warInProgress)
        {
          int i = 0;
          while (buffer[i] != 0)
          {
            i++;
            if (i == MainDeck.deckSize - 1)
              throw new Exception("ну крч игра доиграна не будет они одновременно скинули по пол колоды");
          }
          moves++;
          buffer[i] = player1.UpperCard();
          buffer[i + 1] = player2.UpperCard();

          Console.WriteLine($"Игрок 1 достал {(Cards)buffer[i]}\nИгрок 2 достал {(Cards)buffer[i + 1]}");            Console.WriteLine(moves);
          
          if (buffer[i] == 0 || buffer[i + 1] == 0)
          {
            playerWon = true;
            warInProgress = false;
          }
          
        if (buffer[i] > buffer[i + 1])
          {
            for (int k = 0; k < MainDeck.deckSize; k++)
              if (buffer[k] != 0)
                player1.AddCard(buffer[k]);

            warInProgress = false;
            buffer = new int[MainDeck.deckSize];
          }
          else if (buffer[i] < buffer[i + 1])
          {
            for (int k = 0; k < MainDeck.deckSize; k++)
              if (buffer[k] != 0)
                player2.AddCard(buffer[k]);

              warInProgress = false;
            buffer = new int[MainDeck.deckSize];
          }
        }
      }
    }
  }

  class Program
  {
    public static void PrintArray(Array array)
    {
      foreach(var item in array)
        Console.Write($"{item} ");
      Console.WriteLine();
    }

    public static void Main()
    {
      MainDeck mainDeck = new MainDeck();
      Console.WriteLine();

      // раздача карт на спавне
      Player player1 = new Player(mainDeck.givePart(0), 1);
      Player player2 = new Player(mainDeck.givePart(1), 2);
      
      Game game = new Game(player1, player2);
      game.Start();
    }
  }
}