import { Component, OnInit, ViewChild, ElementRef, OnChanges, HostListener } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material';
import { LinkService, Link } from '../link.service';

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

  constructor(private sanitizer: DomSanitizer, private linkService: LinkService) {
   }

  ngOnInit() {
    this.setVideoSize();
    this.linkService.getRandomLink().subscribe(link => {
      this.setVideoLink(link);
    });
  }

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.setVideoSize();
  }

  private setVideoSize(): void {
    this.videoWidth = Math.min((this.container.nativeElement.offsetWidth - 1) - 50, 540);
    this.videoHeight = this.videoWidth * (9 / 16);
  }

  private setVideoLink(link: Link): void {
    if(!link.youTubeEmbedCode) {
      window.location.href = link.uri;
      return;
    }
    this.videoLink = this.sanitizer.bypassSecurityTrustResourceUrl(`https://www.youtube.com/embed/${link.youTubeEmbedCode}?rel=0&autoplay=1&${link.youTubeStartTime}`);
  }

}
