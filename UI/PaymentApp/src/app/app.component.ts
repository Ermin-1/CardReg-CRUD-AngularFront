import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Lägg till denna rad

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HttpClientModule,  // För att hantera HTTP-anrop
    ReactiveFormsModule, // För att hantera formulär
    CommonModule        // Lägg till CommonModule för 'async' och andra vanliga pipor
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  cards$!: Observable<Card[]>;  // Observable för att hämta kortdata
  cardsForm!: FormGroup;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Initialisera formuläret med kontroller
    this.cardsForm = new FormGroup({
      holderName: new FormControl(''),
      cardnumber: new FormControl(''),
      expireMonth: new FormControl(0),
      expireYear: new FormControl(0),
      cvc: new FormControl('')
    });

    // Hämta kortdata från API:et
    this.cards$ = this.getCards();
  }

  // API-anrop för att hämta kort
  getCards(): Observable<Card[]> {
    return this.http.get<Card[]>('https://localhost:7218/api/Card');
  }

  // Hantera formulärets submit
  onFormSubmit() {
    const addCardRequest = {
      holderName: this.cardsForm.value.holderName,
      cardNumber: this.cardsForm.value.cardnumber,
      expireMonth: this.cardsForm.value.expireMonth,
      expireYear: this.cardsForm.value.expireYear,
      cvc: this.cardsForm.value.cvc
    };

    // Skicka data till API för att spara i databasen
    this.http.post('https://localhost:7218/api/Card', addCardRequest)
      .subscribe({
        next: () => {
          console.log('Kort tillagt');
          this.cards$ = this.getCards(); // Uppdatera listan efter tillägg
          this.cardsForm.reset();  // Rensa formuläret
        },
        error: (err) => console.error('Error:', err)
      });
  }

  // Ta bort ett kort via API
  onDelete(id: string) {
    this.http.delete(`https://localhost:7218/api/Card/${id}`)
      .subscribe({
        next: () => {
          alert('Kort borttaget');
          this.cards$ = this.getCards(); // Uppdatera listan efter borttagning
        },
        error: (err) => console.error('Error:', err)
      });
  }
}

// Modell för kortdata
interface Card {
  id: string;
  holderName: string;
  cardNumber: string;
  expireMonth: number;
  expireYear: number;
  cvc: string;
}
