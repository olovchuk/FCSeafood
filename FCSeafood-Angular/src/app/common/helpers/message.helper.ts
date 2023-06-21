import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";

@Injectable({providedIn: 'root'})
export class MessageHelper {
  constructor(private messageService: MessageService) {
  }

  success(message: string, summary: string = 'Success') {
    this.messageService.add({severity: 'success', summary: summary, detail: message});
  }

  successSticky(message: string, summary: string = 'Success') {
    this.messageService.add({severity: 'success', summary: summary, detail: message, sticky: true});
  }

  info(message: string, summary: string = 'Info') {
    this.messageService.add({severity: 'info', summary: summary, detail: message});
  }

  infoSticky(message: string, summary: string = 'Info') {
    this.messageService.add({severity: 'info', summary: summary, detail: message, sticky: true});
  }

  warning(message: string, summary: string = 'Warning') {
    this.messageService.add({severity: 'warn', summary: summary, detail: message});
  }

  warningSticky(message: string, summary: string = 'Warning') {
    this.messageService.add({severity: 'warn', summary: summary, detail: message, sticky: true});
  }

  error(message: string, summary: string = 'Error') {
    this.messageService.add({severity: 'error', summary: summary, detail: message});
  }

  errorSticky(message: string, summary: string = 'Error') {
    this.messageService.add({severity: 'error', summary: summary, detail: message, sticky: true});
  }

  clear() {
    this.messageService.clear();
  }
}
