export interface Card{
    id: string;           // Guid i C# motsvarar string i TypeScript
  holderName: string;
  cardNumber: string;
  expireMonth: number;
  expireYear: number;
  cvc: number;  
}