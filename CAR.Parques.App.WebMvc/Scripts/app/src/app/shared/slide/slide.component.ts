import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-slide',
  templateUrl: './slide.component.html',
  styleUrls: ['./slide.component.scss']
})
export class SlideComponent implements OnInit {

  @Input() slides: any[] = [];
  @Input() proporcion: number = 50;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    console.log(this.slides);
  }

  sanitizeStyle(url: string) {
    return this.sanitizer.bypassSecurityTrustStyle(url);
  }

  hexToRgb(h: string, isPct: boolean) {
    let r: string = '0', g: string = '0', b: string = '0';
    isPct = isPct === true;
    
    if (h.length == 4) {
      r = "0x" + h[1] + h[1];
      g = "0x" + h[2] + h[2];
      b = "0x" + h[3] + h[3];
      } 
      else if (h.length == 7) {
        r = "0x" + h[1] + h[2];
        g = "0x" + h[3] + h[4];
        b = "0x" + h[5] + h[6];
      }
  
      if (isPct) {
          r = (parseInt(r) / 255 * 100).toFixed(1).toString();
          g = (parseInt(g) / 255 * 100).toFixed(1).toString();
          b = (parseInt(b) / 255 * 100).toFixed(1).toString();
      }
      //console.log("rgb(" + (isPct ? r + "%," + g + "%," + b + "%" : +r + "," + +g + "," + +b) + ", 0.5)");
      return "background-color: rgb(" + (isPct ? r + "%," + g + "%," + b + "%" : +r + "," + +g + "," + +b) + ", 0.5)";
  }
}
