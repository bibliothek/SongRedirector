import { Component, OnInit, ViewChild, ElementRef, OnChanges, HostListener } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material';

@Component({
  selector: 'app-embedded-video',
  templateUrl: './embedded-video.component.html',
  styleUrls: ['./embedded-video.component.scss']
})
export class EmbeddedVideoComponent implements OnInit {
  @ViewChild('container', { static: true }) container: ElementRef;

  videoWidth = 0;
  videoHeight = 0;
  videoLink: SafeResourceUrl;
  songTitle = 'Song Title'

  constructor(private sanitizer: DomSanitizer) {
   }

  ngOnInit() {
    this.setVideoSize();
    this.videoLink = this.sanitizer.bypassSecurityTrustResourceUrl('https://www.youtube.com/embed/a82ZIVHWPpY?rel=0&autoplay=1');
  }

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.setVideoSize();
  }

  private setVideoSize() {
    // this.videoWidth = Math.min((this.container.nativeElement.offsetWidth - 1), 540);
    this.videoWidth = Math.min((this.container.nativeElement.offsetWidth - 1) - 50, 540);
    this.videoHeight = this.videoWidth * (9 / 16);
  }

}
