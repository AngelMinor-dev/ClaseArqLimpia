import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Dog, DogService } from './services/dog.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  dogs:Dog[]=[]

  constructor(private service:DogService){
      this.service.getDogs()
      .subscribe({
        next:chisme=>{this.dogs = chisme}
      });
  }

}
