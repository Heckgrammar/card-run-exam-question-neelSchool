namespace ValidCardRunTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cards = dealCards();
            bool gameWon = false;
            HashSet<int> cardSet = new HashSet<int>(cards);
            foreach (int card in cards)
            {
                if (!cardSet.Contains(card - 1))
                {
                    int ContCnt = 1;
                    while (cardSet.Contains(card + ContCnt))
                    {
                        ContCnt++;
                        if (ContCnt >= 5)
                        {
                            gameWon = true;
                            break;
                        }
                    }
                }
                if (gameWon) break;
            }

            Console.WriteLine(gameWon);
        }

        static int[] dealCards()
        {
            int[] gameCards = new int[500];
            int[] hand = new int[100];
            int cardVal = 1;
            for (int i = 0; i < 500; i += 2)
            {
                gameCards[i] = cardVal;
                gameCards[i + 1] = cardVal;
                cardVal++;
            }
            shuffleCards(gameCards);

            for (int i = 0; i < 100; i++)
            {
                hand[i] = gameCards[i];
            }
            bubbleSort(hand);

            return hand;
        }

        static void shuffleCards(int[] gameCards)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int a = rnd.Next(gameCards.Length);
                int b = rnd.Next(gameCards.Length);
                int temp = gameCards[a];
                gameCards[a] = gameCards[b];
                gameCards[b] = temp;
            }
        }

        static void bubbleSort(int[] hand)
        {
            int n = hand.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (hand[i - 1] > hand[i])
                    {
                        int temp = hand[i - 1];
                        hand[i - 1] = hand[i];
                        hand[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }
    }
}
