import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  OnChanges,
  HostListener
} from "@angular/core";
import { DomSanitizer, SafeResourceUrl } from "@angular/platform-browser";
import { MatIconRegistry } from "@angular/material";
import { LinkService, Link } from "../link.service";
import { State } from "../reducers";
import { Store, select } from "@ngrx/store";
import { fetchData } from "../link.actions";

@Component({
  selector: "app-embedded-video",
  templateUrl: "./embedded-video.component.html",
  styleUrls: ["./embedded-video.component.scss"]
})
export class EmbeddedVideoComponent implements OnInit {
  @ViewChild("container", { static: true }) container: ElementRef;

  videoWidth = 0;
  videoHeight = 0;
  videoLink: SafeResourceUrl;
  songTitle = "Song Title";

  constructor(
    private sanitizer: DomSanitizer,
    private linkService: LinkService,
    private store: Store<State>
  ) {}

  ngOnInit() {
    this.setVideoSize();
    this.store.pipe(select("link")).subscribe(link => {
      if (link && link.currentLink) {
        this.setVideoLink(link.currentLink);
        this.songTitle = link.currentLink.displayName;
      }
    });
    this.store.dispatch(fetchData());
  }

  @HostListener("window:resize", ["$event"])
  onResize() {
    this.setVideoSize();
  }

  private setVideoSize(): void {
    this.videoWidth = Math.min(
      this.container.nativeElement.offsetWidth - 1 - 50,
      540
    );
    this.videoHeight = this.videoWidth * (9 / 16);
  }

  private setVideoLink(link: Link): void {
    if (!link.youTubeEmbedCode) {
      window.location.href = link.uri;
      return;
    }
    this.videoLink = this.sanitizer.bypassSecurityTrustResourceUrl(
      `https://www.youtube.com/embed/${link.youTubeEmbedCode}?rel=0&autoplay=1&${link.youTubeStartTime}`
    );
  }
}
