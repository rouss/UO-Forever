#region Header
//   Vorspire    _,-'/-'/  Admin.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2014  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Server.Gumps;
using Server.Mobiles;

using VitaNex.SuperGumps.UI;
#endregion

namespace VitaNex.Modules.TrashCollection
{
	public sealed class TrashCollectionAdminGump : ListGump<BaseTrashHandler>
	{
		public TrashCollectionAdminGump(PlayerMobile user, Gump parent = null)
			: base(user, parent, emptyText: "There are no trash handlers to display.", title: "Trash Collection Control Panel")
		{
			ForceRecompile = true;
		}

		public override string GetSearchKeyFor(BaseTrashHandler key)
		{
			return key != null ? key.GetType().FullName : base.GetSearchKeyFor(null);
		}

		protected override int GetLabelHue(int index, int pageIndex, BaseTrashHandler entry)
		{
			return entry != null ? (entry.Enabled ? HighlightHue : ErrorHue) : base.GetLabelHue(index, pageIndex, null);
		}

		protected override string GetLabelText(int index, int pageIndex, BaseTrashHandler entry)
		{
			return entry != null ? entry.GetType().Name : base.GetLabelText(index, pageIndex, null);
		}

		protected override void CompileList(List<BaseTrashHandler> list)
		{
			list.Clear();
			list.AddRange(TrashCollection.Handlers.Values);
			base.CompileList(list);
		}

		protected override void CompileMenuOptions(MenuGumpOptions list)
		{
			if (User.AccessLevel >= TrashCollection.Access)
			{
				list.AppendEntry(new ListGumpEntry("System Options", OpenConfig, HighlightHue));
			}

			list.AppendEntry(new ListGumpEntry("View Profiles", ShowProfiles));
			list.AppendEntry(new ListGumpEntry("Help", ShowHelp));
			base.CompileMenuOptions(list);
		}

		protected override void SelectEntry(GumpButton button, BaseTrashHandler entry)
		{
			base.SelectEntry(button, entry);

			MenuGumpOptions opts = new MenuGumpOptions();

			if (User.AccessLevel >= TrashCollection.Access)
			{
				opts.AppendEntry(
					new ListGumpEntry(
						"Options",
						b =>
						{
							Refresh();

							PropertiesGump pg = new PropertiesGump(User, Selected)
							{
								X = b.X,
								Y = b.Y
							};
							User.SendGump(pg);
						},
						HighlightHue));

				opts.AppendEntry(
					new ListGumpEntry("Accept List", b => Send(new TrashHandlerAcceptListGump(User, entry, Hide(true))), HighlightHue));

				opts.AppendEntry(
					new ListGumpEntry("Ignore List", b => Send(new TrashHandlerIgnoreListGump(User, entry, Hide(true))), HighlightHue));

				opts.AppendEntry(
					new ListGumpEntry(
						entry.Enabled ? "Disable" : "Enable",
						b1 =>
						{
							entry.Enabled = !entry.Enabled;
							Refresh(true);
						},
						entry.Enabled ? ErrorHue : HighlightHue));

				opts.AppendEntry(new ListGumpEntry("Cancel", b => { }));
			}

			Send(new MenuGump(User, Refresh(), opts, button));
		}

		private void OpenConfig(GumpButton btn)
		{
			Minimize();

			PropertiesGump p = new PropertiesGump(User, TrashCollection.CMOptions)
			{
				X = X + btn.X,
				Y = Y + btn.Y
			};

			User.SendGump(p);
		}

		private void ShowProfiles(GumpButton button)
		{
			if (User != null && !User.Deleted)
			{
				Send(new TrashCollectionProfilesGump(User, Hide()));
			}
		}

		private void ShowHelp(GumpButton button)
		{
			if (User == null || User.Deleted)
			{
				return;
			}

			StringBuilder sb = TrashCollectionGumpUtility.GetHelpText(User);
			Send(
				new HtmlPanelGump<StringBuilder>(User, Refresh())
				{
					Selected = sb,
					Html = sb.ToString(),
					Title = "Trash Collection Help",
					HtmlColor = Color.SkyBlue
				});
		}
	}
}