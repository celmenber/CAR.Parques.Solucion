import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss'],
  animations: [
    trigger('fadeInOut', [
          state('in', style({ opacity: 100 })),
          transition('* => void', [
                animate(300, style({ opacity: 0 }))
          ])
    ])
]
})
export class FileUploadComponent implements OnInit {
  
  @Input() text = 'Cargar Imagen Principal';
  /** Name used in form which will be sent in HTTP request. */
  @Input() param = 'file';
  /** Target URL for file uploading. */
  @Input() target = 'https://file.io';
  /** File extension that accepted, same as 'accept' of <input type="file" />. 
  By the default, it's set to 'image/*'. */
  @Input() accept = 'image/*';
  /** Allow you to add handler after its completion. Bubble up response text from remote. */
  @Output() complete = new EventEmitter<string>();

  files: Array<FileUploadModel> = [];

  constructor() { }

  ngOnInit(): void {
  }

  onClick() {
}

  cancelFile(file: FileUploadModel) {
}

retryFile(file: FileUploadModel) {
}

private uploadFile(file: FileUploadModel) {
}

private uploadFiles() {
}

private removeFileFromArray(file: FileUploadModel) {
}

}


export class FileUploadModel {
  data: File;
  state: string;
  inProgress: boolean;
  progress: number;
  canRetry: boolean;
  canCancel: boolean;
//sub?: Subscription;
}
