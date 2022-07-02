import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { DecryptIoComponent } from './components/decrypt-io/decrypt-io.component';
import { EncryptIoComponent } from './components/encrypt-io/encrypt-io.component';
import { SignIoComponent } from './components/sign-io/sign-io.component';
import { VerifyIoComponent } from './components/verify-io/verify-io.component';
import { MatdialogService } from './helpers/mat-dialog.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // dialog
  public mDialog: any;

  title = 'PdfSignPro';
  src = 'https://vadimdez.github.io/ng2-pdf-viewer/assets/pdf-test.pdf';
  filePdf: any;
  /**
   *
   */
  constructor(private imDialog: MatDialog,
    public imDialogService: MatdialogService,
    private http: HttpClient,) {

    this.mDialog = imDialogService;
    this.mDialog.initDialg(imDialog);
  }

  // thực hiện ký
  public sign() {
    var data = {
      filePdf: this.filePdf
    }
    this.showPopup(data);
  }

  // xác thực chữ ký
  public verify() {

    let url = environment.url + "VerifySignature";

    const formData = new FormData();
    formData.append('formFile', this.filePdf);

    this.http.post(url, formData).subscribe((res: any) => {
      this.mDialog.setDialog(
        this,
        VerifyIoComponent,
        "",
        "",
        res.message,
        "50%",
        "60vh",
        1
      );
      this.mDialog.open();
    });
  }

  // mã hóa file
  public encrypt() {
    var data = {
      filePdf: this.filePdf
    }
    this.mDialog.setDialog(
      this,
      EncryptIoComponent,
      "",
      "",
      data,
      "50%",
      "60vh",
      1
    );
    this.mDialog.open();
  }
  // giải mã file
  public decrypt() {
    var data = {
      filePdf: this.filePdf
    }
    this.mDialog.setDialog(
      this,
      DecryptIoComponent,
      "",
      "",
      data,
      "50%",
      "60vh",
      1
    );
    this.mDialog.open();
  }
  // hiển thị popup
  public showPopup(data?: any) {
    this.mDialog.setDialog(
      this,
      SignIoComponent,
      "",
      "",
      data,
      "50%",
      "50vh",
      1
    );
    this.mDialog.open();
  }

  // render pdf ra view
  onFileSelected(event: any) {
    let $img: any = document.querySelector('#file-input');

    if (typeof (FileReader) !== 'undefined') {
      let reader = new FileReader();

      reader.onload = (e: any) => {
        this.src = e.target.result;
      };

      reader.readAsArrayBuffer($img.files[0]);
    }
    this.filePdf = event.target.files[0];
  }
}
