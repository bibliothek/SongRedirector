import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  HostListener
} from "@angular/core";
import { DomSanitizer, SafeResourceUrl } from "@angular/platform-browser";
import { Link } from "../link.model";
import { State } from "../reducers";
import { Store, select } from "@ngrx/store";
import { fetchLink, downvote, upvote } from "../link.actions";
import { ActivatedRoute } from "@angular/router";

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
  link: Link;

  constructor(
    private sanitizer: DomSanitizer,
    private store: Store<State>,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.setVideoSize();
    this.store.pipe(select("link")).subscribe(link => {
      if (link) {
        this.link = link.currentLink;
        if (link.newLink) {
          this.setVideoLink(link.currentLink);
        }
      }
    });
    this.route.params.subscribe(() => {
      this.store.dispatch(fetchLink());
    });
  }

  @HostListener("window:resize")
  onResize() {
    this.setVideoSize();
  }

  getAnotherLink(): void {
    this.store.dispatch(fetchLink());
  }

  upvote(): void {
    this.store.dispatch(upvote());
  }

  downvote(): void {
    this.store.dispatch(downvote());
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
