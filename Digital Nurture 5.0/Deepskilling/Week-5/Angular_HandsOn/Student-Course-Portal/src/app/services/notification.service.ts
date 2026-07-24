import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {
  readonly messages: string[] = [];

  push(message: string): void {
    this.messages.push(message);
  }
}
