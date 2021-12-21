import { Component, Input  } from '@angular/core';

@Component({
  selector: 'app-render-html',
  templateUrl: './render-html.component.html',
  styleUrls: ['./render-html.component.scss']
})
export class RenderHtmlComponent {
  @Input()  htmlText : string;
}
