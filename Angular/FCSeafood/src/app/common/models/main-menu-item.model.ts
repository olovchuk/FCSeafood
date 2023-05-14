export class MainMenuItemModel {
  id: number;
  text: string;
  link: string;
  popup: any;

  constructor(id: number,
              text: string,
              link: string,
              popup: any) {
    this.id = id;
    this.text = text;
    this.link = link;
    this.popup = popup;
  }
}
