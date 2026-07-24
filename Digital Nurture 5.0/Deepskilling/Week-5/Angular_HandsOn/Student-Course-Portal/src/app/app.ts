import { AsyncPipe, NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header.component';
import { LoadingService } from './services/loading.service';

@Component({
  selector: 'app-root',
  imports: [AsyncPipe, HeaderComponent, NgIf, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  readonly loadingService = inject(LoadingService);
}
